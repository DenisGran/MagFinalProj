import socket, _thread, os

os.system("title Samung server")
print("*-Samung server-*")
print("\nStarting...\n\n")

bind_ip = '127.0.0.1'
bind_port = 1450 #Our used protocol will be 1450
max_connections = 50 #Maximum connections this computer can handle
curr_connections = 0

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((bind_ip, bind_port))
server.listen(5)  # max of qued connections

print('Listening on port', bind_port)

def handle_client_connection(client_socket, client_address, client_port):
	global curr_connections

	curr_connections += 1
	recievedMsg = client_socket.recv(1024) #Maximum size recieved
	print('From', str(client_address) + ":" + str(client_port), 'Recieved:\n' + str(recievedMsg))
	client_socket.send(bytes('testing 123', 'utf-8'))
	client_socket.close()
	curr_connections -= 1

def main():
	while True:
		global max_connections
		global curr_connections

		client_sock, address = server.accept()
		if(curr_connections <= max_connections):
			print('Accepted connection from', str(address[0]) + ":" + str(address[1])) #IP:PORT
			client_handler = _thread.start_new_thread( handle_client_connection, (client_sock, address[0], address[1],))
		else:
			client_sock.send(bytes("denied", 'utf-8'))
			client_socket.close()

if __name__ == '__main__':
	main()