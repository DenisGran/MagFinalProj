import os
os.system("git add -A")
print("Commit changes:")
thisChanges = input()
os.system('git commit -m"' + thisChanges + '"')
os.system('git push origin master')
print("===================================\nDone")
os.system('pause')