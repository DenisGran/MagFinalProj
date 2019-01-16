#This is the database module
import sys, time, sqlite3
from threading import Lock

class my_DB: #FDatabase = File Database

	__mutex = Lock()

	def check_user_details(self, uid, *password):
		'''This function checks if the given details are correct'''

		res = False
		if(password): #If the password is given we search for uid and password
			given_password = password[0] #Doing this because the password is passed as tuple
			print("Searching account [ " + uid + " , " + given_password + " ]")
			result = self.__cursor.execute('select 1 from users where uid="' + uid + '" and password="' + given_password + '";')
		else: #If password isn't given we just search for the uid
			print("Searching user", uid)
			result = self.__cursor.execute('select 1 from users where uid="' + uid + '";')

		if(result.fetchone()): #If the result isn't nontype the user exists
			res = True
		print("check_user_details finished res=", res)
		return res

	def add_user(self, uid, password, curr_IP, target_port, user_type):
		'''Adds/Updates a user in the database'''

		res = False
		self.__mutex.acquire() #Locking the MUTEX
		if(self.check_user_details(uid)):
			print("User already exists, updating details")
			try:
				self.__cursor.execute('update users set password="' + password + '",curr_ip="' + curr_IP + '",target_port=' + target_port + ' where uid="' + uid + '";')
				self.__connection.commit() #Applying changes
				print("User [" + uid + "] details updated")
				res = True
			except Exception as e:
				print("Something went wrong... couldn't add user to DB. Details:\n", str(e))
		else:
			print("Adding new user...")
			try:
				self.__cursor.execute('insert into users values("' + uid + '","' + password + '","' + curr_IP + '",' + target_port + ',"' + user_type + '");')
				self.__connection.commit() #Applying changes
				res = True
			except Exception as e:
				print("Something went wrong... couldn't add user to DB. Details:\n", str(e))
		self.__mutex.release() #Releasing the MUTEX
		return res

	def reset_user_current_ip(self, uid):
		'''This function resets the current ip of a user'''

		try:
			print("Resetting user", uid, "current ip in DB\n")
			self.__cursor.execute('update users set curr_ip=null where uid="' + uid + '";')
			self.__connection.commit() #Applying changes
		except Exception as e:
			print("Something went wrong... couldn't reset user's ip in DB. Details:\n", str(e))
		return

	def reset_all_users_current_ip(self, connected_users):
		'''This function resets all current ips of users in db'''

		print("Beginning to erase all current users ips")
		for user in connected_users:
			self.reset_user_current_ip(user.uid)
		return

	def print_user_details(self, uid):
		'''For testing purposes ONLY'''

		try:
			result = self.__cursor.execute('select * from users where uid="' + uid + '";')
			print(result.fetchone())
		except:
			print("User not found")
		return

	def __check_if_table_exist(self):
		'''Checks if table exists and creates if it doenst'''
		try:
			self.__cursor.execute("select 0 from users;") #Checking if tables exists
			print("Table exists.")
		except sqlite3.Error: #If the table does not exist we create it
			print("Table does not exist. Creating it...")
			__tableStructure = "CREATE TABLE USERS(UID STRING PRIMARY KEY NOT NULL, PASSWORD STRING NOT NULL, CURR_IP STRING NOT NULL, TARGET_PORT INT NOT NULL, TYPE STRING NOT NULL);"
		return

	def __init__(self):
		'''Constructor'''
		self.__name = "ourdatabase.db"
		self.__connection = sqlite3.connect(self.__name, check_same_thread=False)
		self.__cursor = self.__connection.cursor()
		self.__check_if_table_exist()

		#Structure explanation:
		#UID= Unique user detail| password= MD5 hash of user's password| curr_ip= Current user's ip to connect| target_port= Current user's port to connect| type= professional/private

	def __del__(self):
		'''Deconstructor'''

		self.__connection.close()
