import socket, _thread, os, sys, db
from user import user_session

os.system("title Samung server")
print("\n*-Samung server-*")
print("\nStarting...\n\n")

bind_ip = '127.0.0.1'
bind_port = 1450 #Used protocol is 1450
max_connections = 50 #Maximum connections this computer can handle
curr_connections = 0

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
try:
	server.bind((bind_ip, bind_port))
except: #Making sure the IP/PORT aren't used
	print("PORT OR IP IS ALREADY IN USE. CANNOT LAUNCH SERVER.")
	sys.exit(1) #Stopping the program

server.listen(5)  # max of qued connections

theDB = db.my_DB()
print("Database loaded.")
testingDB = False
print("MAX CONNECTIONS:", max_connections, "\nListening on port", bind_port)

if(testingDB):
	print("\n**Database testing begins")
	if(theDB.check_user_details("12366TEsT")):
		print("User exists")
	else:
		print("User does not exist")
	theDB.add_user("123TEsT", "pa$$", "999", "1223", "private")
	theDB.print_user_details("123TEsT")
	theDB.add_user("1234TEsT", "pa$$2", "9992", "12236", "professional")
	theDB.print_user_details("1234TEsT")
	print("**Database testing ends\n")

def send_message(client_sock, message):
	'''Sends a message to socket and encodes it'''

	client_sock.send(bytes(message, 'utf-8'))
	return

def recieve_message(client_sock):
	'''Recieves a message from socket and decodes it'''

	return (client_sock.recv(1024)).decode("utf-8") #Maximum message size recieved

def handle_sign_in(client_socket, request, client_address, client_port):
	'''This function handles sgin request'''

	res = None
	request_code = 0 #Index number
	uid = 1 #Index number
	password = 2 #Index number
	wrong_details_code = "00,newUID"
	user_registered_code = "01"
	failure_code = "02"
	request_parameters = request.split(',') #Splitting the request by ,

	if(len(request_parameters) >= 3): #Making sure we have at least 3 parameters
		try:
			if(theDB.check_user_details(request_parameters[uid])): #Checking if user exists
				if(theDB.check_user_details(request_parameters[uid], str(request_parameters[password]))): #Checking if this uid is already registered
					res = user_session(request_parameters[uid], client_address, client_port, "private") #User is logged in
					#TODO: Decide when to use professional type of user
				else:	#If the details don't match we wait for new uid & password
					send_message(client_socket, wrong_details_code)
			else:
				#If this is a new user
				try:
					theDB.add_user(request_parameters[uid], str(request_parameters[password]), client_address, client_port, "private")
					#^^^ TODO: CHOOSE WHEN ACCOUNT TYPE IS PROFESSIONAL
					send_message(client_socket, user_registered_code)
				except: #If a crazy exception occured, send error to the server
					send_message(client_socket, failure_code)
		except Exception as e:
			print(e)
	else:
		send_message(client_socket, failure_code)
	return res

def handle_change_password(client_socket, client_address, client_port, recieved_msg):
	'''This function handle nps request'''

	res = False
	recieved_parameters = list(recieved_msg)
	if(len(request_parameters) >= 3): #Making sure we have at least 3 parameters
		uid = recieved_parameters[1]
		new_password = str(recieved_parameters[2])

		try:
			theDB.add_user(uid, new_password, client_address, client_port, "private")
			send_message(client_address, "01") #Returning 01 if OK
		except:
			print("Couldn't change password of user", uid)
			send_message(client_address, "02") #Returning 02 if failed
	return res

def handle_client_connection(client_socket, client_address, client_port):
	'''Handles every client that connects'''

	global curr_connections
	logged_in = False
	this_user = user_session()
	unknow_request = "02"

	curr_connections += 1
	print("Current connections:", curr_connections)
	if(max_connections == curr_connections):
		print("Max connections has been reached, not accepting new connections")
	try:
		while True: #Endless loop until client closes connection
			recievedMsg = str(recieve_message(client_socket))
			print('From', str(client_address) + ":" + str(client_port), 'Recieved:\n' + recievedMsg)
			if(logged_in): #Functions for logged in users only
  		  		if('nps' in recievedMsg):
  		  			handle_change_password(client_socket, client_address, client_port, recievedMsg)
			else:
				if("sgin" in recievedMsg):
					this_user = handle_sign_in(client_socket, recievedMsg, client_address, client_port)
					if(this_user): #If the returned object is not none user is logged in
						logged_in = True
				else:
					send_message(client_socket, unknow_request)
	except:
		client_socket.close()
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