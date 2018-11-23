import socket, _thread, os, sys, mysql.connector

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

print("MAX CONNECTIONS:", max_connections, "\nListening on port", bind_port)

def sendMessage(clientsock, message):
	'''Sends a message to socket and encodes it'''
	clientsock.send(bytes(message, 'utf-8'))
	return

def recieveMessage(clientsock):
	'''Recieves a message from socket and decodes it'''
	return (clientsock.recv(1024)).decode("utf-8") #Maximum message size recieved

def handle_client_connection(client_socket, client_address, client_port):
	'''Handles every client that connects'''
	global curr_connections

	curr_connections += 1
	print("Current connections:", curr_connections)
	if(max_connections == curr_connections):
		print("Max connections has been reached, not accepting new connections")
	try:
		while True: #Endless loop until client closes connection
			recievedMsg = recieveMessage(client_socket)
			print('From', str(client_address) + ":" + str(client_port), 'Recieved:\n' + str(recievedMsg))
			sendMessage(client_socket, str(recievedMsg) + "1")
	except:
		client_socket.close()
		print("Client", str(client_address) + ":" + str(client_port), "has closed connection.")
	curr_connections -= 1
	print("Curr_connections =", curr_connections)
	return

def isFull():
	'''Checks if server has reached max connections and returns bool'''
	global curr_connections
	global max_connections

	if(curr_connections + 1 < max_connections): #Adding 1 so the count will be currect.
		return False
	return True

def accept_connections():
	'''Accepts/declines connections'''

	if(not isFull()): #Checking if server isn't full
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