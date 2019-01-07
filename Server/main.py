import socket, _thread, os, sys
import db, testDB
from user import user_session

os.system("title Samung server")
print("\n*-Samung server-*")
print("\nStarting...\n\n")

bind_ip = '127.0.0.1'
bind_port = 1450 #Used protocol is 1450
max_connections = 50 #Maximum connections this computer can handle
curr_connections = 0

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
the_db = db.my_DB()
print("Database loaded.")
testingDB = False
success_code = "01"
failure_code = "02"
unknown_request = "denied"
connected_users = {} #Key is IP value is user_session object

try:
	server.bind((bind_ip, bind_port))
except: #Making sure the IP/PORT aren't used
	print("PORT OR IP IS ALREADY IN USE. CANNOT LAUNCH SERVER.")
	sys.exit(1) #Stopping the program

server.listen(5)  # max of qued connections
print("MAX CONNECTIONS:", max_connections, "\nListening on port", bind_port, "\n\n-Server started-\n\n")

if(testingDB):
	testDB()

def send_message(client_sock, message):
	'''Sends a message to socket and encodes it'''

	client_sock.send(bytes(message, 'utf-8'))
	return

def recieve_message(client_sock):
	'''Recieves a message from socket and decodes it'''

	return (client_sock.recv(1024)).decode("utf-8") #Maximum message size recieved

def handle_sign_in(client_socket, client_address, client_port, request):
	'''This function handles sgin request'''

	res = None
	request_code = 0 #Index number
	uid = 1 #Index number
	password = 2 #Index number
	wrong_details_code = "00,newUID"
	request_parameters = request.split(',') #Splitting the request by ,

	print("Handle sign in function\n")
	if(len(request_parameters) == 3): #Making sure we have at 3 parameters
		try:
			if(the_db.check_user_details(request_parameters[uid])): #Checking if user exists
				if(the_db.check_user_details(request_parameters[uid], str(request_parameters[password]))): #Checking if this uid is already registered
					res = user_session(request_parameters[uid], client_address, str(client_port), "private", client_socket) #User is logged in
					send_message(client_socket, success_code)
					print("User", request_parameters[uid] , "logged in\n")
					#TODO: Decide when to use professional type of user
					#TODO: Hash SHA256 the passwords
				else:	#If the details don't match we wait for new uid & password
					print("User gave wrong details\n")
					send_message(client_socket, wrong_details_code) #Todo add cooldown for 5 seconds to prevent spam
			else:
				#If this is a new user
				try:
					print("Adding new user\n")
					if(the_db.add_user(request_parameters[uid], str(request_parameters[password]), client_address, str(client_port), "private")):
						#^^^ TODO: CHOOSE WHEN ACCOUNT TYPE IS PROFESSIONAL
						res = user_session(request_parameters[uid], client_address, str(client_port), "private", client_socket) #User is logged in
						send_message(client_socket, success_code)
					else:
						send_message(client_socket, failure_code)
				except Exception as e: #If a crazy exception occured, send error to the client
					print("While trying to add new user exception occurred:\n" + str(e))
					send_message(client_socket, failure_code)

			if(res): #If the returned object is not none user is logged in
						try:
							connected_users[client_address] = res
							print("Added new user to connected_users")
							print("User", str(res.uid), str(res.current_ip), str(res.current_port), str(res.type), "logged in\n")
						except Exception as e:
							print("Exception:", str(e))

		except Exception as e:
			print("An exception occured:", str(e))
	else:
		print("User didn't send 3 parameters to signin function.\n")
		send_message(client_socket, failure_code)

	return

def handle_change_password(client_socket, client_address, client_port, recieved_msg):
	'''This function handle nps request'''

	res = False
	recieved_parameters = recieved_msg.split(',')
	print("Handle_Change_Password")
	if(len(recieved_parameters) == 3): #Making sure we have at least 3 parameters
		uid = recieved_parameters[1]
		new_password = str(recieved_parameters[2])

		try:
			the_db.add_user(uid, str(new_password), client_address, str(client_port), "private")
			send_message(client_socket, success_code) #Returning 01 if OK
			res = True
		except Exception as e:
			print("Couldn't change password of user [" + uid + "] Reason:\n" + str(e) + "\n")
			send_message(client_address, failure_code) #Returning 02 if failed
	else:
		print("handle_change_password function requires 3 parameters.\n")
		send_message(client_address, failure_code)

	return res

def handle_peer_connect(client_socket, client_address, client_port, recieved_msg):
	'''This function handles every client that wants to create a p2p connection'''

	print("Starting handle_peer_connect")
	user_to_connect_index = 1
	parameters_amount = 2
	recieved_parameters = recieved_msg.split(',')
	if(len(recieved_parameters) < parameters_amount):
		send_message(client_socket, failure_code)
		print("handle_peer_connect function uses 2 parameters")
	else:
		print("Recieved parameters =", recieved_parameters)
		user_to_connect = recieved_parameters[user_to_connect_index]
		print("user_to_connect =", recieved_parameters[user_to_connect_index])
		#^^The user to connect

		try:
			if(user_to_connect in connected_users):
				user_to_connect_socket = connected_users[user_to_connect].socket
				print("user_to_connect_socket =", user_to_connect_socket)
				send_message(user_to_connect_socket, "req," + connected_users[client_address].uid)
				recieve_message(user_to_connect_socket) #Waiting for response
			else:
				print("User is not connected")
				send_message(client_socket, failure_code)

		except Exception as e:
			print("An exception occured: " + e)

	return

def handle_client_connection(client_socket, client_address, client_port):
	'''Handles every client that connects'''

	global curr_connections
	global connected_users
	logged_in = False
	available_signedin_functions = {'nps' : handle_change_password, "con" : handle_peer_connect}

	available_non_signedin_functions = {'sgin' : handle_sign_in}

	available_args = {'nps' : [client_socket, client_address, client_port],
	 "sgin" : [client_socket, client_address, client_port],
	 "con" : [client_socket, client_address, client_port]}

	requested_function = ""
	requested_function_index = 0

	curr_connections += 1
	print("Current connections:", curr_connections)

	if(max_connections == curr_connections):
		print("Max connections has been reached, not accepting new connections")

	try:
		while True: #Endless loop until client closes connection
			recievedMsg = str(recieve_message(client_socket))
			print('From', str(client_address) + ":" + str(client_port), 'Recieved:\n' + recievedMsg)
			requested_function = recievedMsg.split(',')[requested_function_index] #The first result from the split is the requested function
			print("requested_function =", requested_function)

			if(logged_in): #Functions for logged in users only
				if(requested_function in available_signedin_functions):
					available_signedin_functions[requested_function](*available_args[requested_function], recievedMsg)

				else:
					print("Something went wrong. Unknown request.\n")
					send_message(client_socket, unknown_request)

			else: #If user isn't logged in yet
				if(requested_function in available_non_signedin_functions): #Making sure the request is valid
					available_non_signedin_functions[requested_function](*available_args[requested_function], recievedMsg)
					if(client_address in connected_users): #Checking is signin function added the user to the conencted users list
						logged_in = True #If the user was added, it has logged in.

				else:
					print("Recieved unknown request.\n")
					send_message(client_socket, unknown_request)
	except:
		pass
	client_socket.close()

	if(client_address in connected_users): #If user is registered, delete it
		#the_db.reset_user_current_ip(connected_users[client_address].uid) #Resetting the current ip in db
		#^^^No need for this while we are testing
		del connected_users[client_address]

	print("Client", str(client_address) + ":" + str(client_port), "has closed connection.")
	curr_connections -= 1
	print("Curr_connections =", curr_connections)

	return

def is_full():
	'''Checks if server has reached max connections and returns bool'''

	global curr_connections
	global max_connections

	if(curr_connections + 1 < max_connections): #Adding 1 so the count will be currect.
		return False

	return True

def accept_connections():
	'''Accepts/declines connections'''

	if(not is_full()): #Checking if server isn't full
		client_sock, address = server.accept()
		print('Accepted connection from', str(address)) #IP:PORT
		client_handler = _thread.start_new_thread( handle_client_connection, (client_sock, address[0], address[1],))

	return

def main():
	while True:
		accept_connections()

	return

if __name__ == '__main__':
	main()