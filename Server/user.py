class user_session():

	def __init__(self, *parameters):
		'''Constructor, format: uid,current ip,current port,type,socket'''

		if(len(parameters) == 5): #Making sure we have 5 parameters
			self.uid=parameters[0]
			self.current_ip=parameters[1]
			self.current_port=parameters[2]
			self.type=parameters[3]
			self.socket=parameters[4]
			self.logged_in=False
		else:
			print("Error, you should provide 5 parameters to user_session object.")