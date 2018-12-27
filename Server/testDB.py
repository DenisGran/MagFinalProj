def testDB():
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