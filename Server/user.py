class user_session():

	def __init__(self, *parameters):
		'''Constructor, format: uid,current ip,current port,type'''

		if(len(parameters) == 4): #Making sure we have at least 4 parameters
			self.uid=parameters[0]
			self.current_ip=parameters[1]
			self.current_port=parameters[2]
			self.type=parameters[3]
		else:
			print("Error, you should provide 4 parameters to user_session object.")