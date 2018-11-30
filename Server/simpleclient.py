import socket

#THIS CLIENT IS FOR TESTING PURPOSES ONLY

targetPort = 1450 #Program's port
targetIP = "127.0.0.1"

# create an ipv4 (AF_INET) socket object using the tcp protocol (SOCK_STREAM)
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# connect the client
client.connect((targetIP, targetPort))

# send some data (in this case a HTTP GET request)
try:
	while True:
		print("Enter a query:")
		query = input()
		# receive the response data (4096 is recommended buffer size)
		client.send(bytes(query, 'utf-8'))
		print("Sent to server...")
		response = client.recv(4096)
		print(str(response))
except KeyboardInterrupt:
	print("Stopping")

print(str(response))
client.close()