class user_session():

	def __init__(self, *parameters):
		'''Constructor, format: uid,current ip,current port,type'''

		parameter_list = list(parameters)
		if(len(parameter_list) > 4): #Making sure we have at least 4 parameters
			self.uid=parameter_list[0]
			self.current_ip=parameter_list[1]
			self.current_port=parameter_list[2]
			self.type=parameter_list[3]