import sqlite3

connection = sqlite3.connect("ourdatabase.db")
connection.execute("delete from Users;")
connection.commit()
connection.close()