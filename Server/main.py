import socket, _thread, os, sys, db

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
testingDB = True
print("MAX CONNECTIONS:", max_connections, "\nListening on port", bind_port)

if(testingDB):
	print("**Database testing begins")
	if(theDB.check_user_exists("12366TEsT")):
		print("User exists")
	else:
		print("User does not exist")
	theDB.add_user("123TEsT", "pa$$", "999", "1223", "private")
	theDB.print_user_details("123TEsT")
	theDB.add_user("1234TEsT", "pa$$2", "9992", "12236", "professional")
	theDB.print_user_details("1234TEsT")
	print("**Database testing ends")

def send_message(client_sock, message):
	'''Sends a message to socket and encodes it'''
	client_sock.send(bytes(message, 'utf-8'))
	return

def recieve_message(client_sock):
	'''Recieves a message from socket and decodes it'''
	return (client_sock.recv(1024)).decode("utf-8") #Maximum message size recieved

def handle_client_connection(client_socket, client_address, client_port):
	'''Handles every client that connects'''
	global curr_connections

	curr_connections += 1
	print("Current connections:", curr_connections)
	if(max_connections == curr_connections):
		print("Max connections has been reached, not accepting new connections")
	try:
		while True: #Endless loop until client closes connection
			recievedMsg = recieve_message(client_socket)
			print('From', str(client_address) + ":" + str(client_port), 'Recieved:\n' + str(recievedMsg))
			send_message(client_socket, str(recievedMsg) + "1")
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