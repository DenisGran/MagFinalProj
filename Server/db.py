#This is the database module
import sys, time, sqlite3
from threading import Lock

class my_DB: #FDatabase = File Database

	__mutex = Lock()

	def check_user_exists(self, uid):
		'''Checks if user is already in the db'''

		res = False
		print("Searching user", uid)
		result = self.__cursor.execute('select 1 from users where uid="' + uid + '";')
		if(result.fetchone()): #If the result isn't nontype the user exists
			res = True
		return res

	def add_user(self, uid, password, curr_IP, target_port, type):
		'''Adds/Updates a user in the database'''

		self.__mutex.acquire() #Locking the MUTEX
		if(self.check_user_exists(uid)):
			print("User already exists, updating details")
			#target_port=6665 where uid="123TEsT";
			try:
				self.__cursor.execute('update users set password="' + password + '",curr_ip="' + curr_IP + '",target_port=' + target_port + ' where uid="' + uid + '";')
				self.__connection.commit(); #Applying changes
			except Exception as e:
				print("Something went wrong... couldn't add user to DB. Details:\n", str(e))
		else:
			print("Adding new user...")
			try:
				self.__cursor.execute('insert into users values("' + uid + '","' + password + '","' + curr_IP + '",' + target_port + ',"' + type + '");')
				self.__connection.commit();#Applying changes
			except Exception as e:
				print("Something went wrong... couldn't add user to DB. Details:\n", str(e))
		self.__mutex.release() #Releasing the MUTEX

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
			__tableStructure = "CREATE TABLE USERS(UID STRING PRIMARY KEY NOT NULL, PASSWORD STRING NOT NULL, CURR_IP STRING UNIQUE NOT NULL, TARGET_PORT INT NOT NULL, TYPE STRING NOT NULL);"
		return

	def __init__(self):
		'''Constructor'''

		self.__name = "ourdatabase.db"
		self.__dbStructure = {"uid":"", "password":"", "curr_IP":"", "target_port" :"", "type":""}
		self.__connection = sqlite3.connect(self.__name)
		self.__cursor = self.__connection.cursor()
		self.__check_if_table_exist()

		#Structure explanation:
		#UID= Unique user id| password= MD5 hash of user's password| curr_ip= Current user's ip to connect| target_port= Current user's port to connect| type= professional/private

	def __del__(self):
		'''Deconstructor'''

		self.__connection.close()