#KEK MING HUAI
#TP068569

def CMenu(username,password): #Registered customer menu
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()

    oldcustdo=input("What would you like to do?\n[V] View catalog\n[S] Search medicine\n[A] Account details\n[C] My cart\n[X] Exit\n")
    if oldcustdo.strip().lower()=="v":
        medicines=open("medicines.txt","r")
        for lines in medicines:
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
                print("Name: "+content[0]+"\nCategory: "+content[7].capitalize()+"\nHalal Status (Yes/No/Unknown): "+content[1]+"\nExpiration Date: "+content[2]+"\nVolume or Tablets: "+content[3]+"\nPrice: RM"+content[4]+"\nRemaining Stock: "+content[5]+"\n")
        CMenu(username,password)
    elif oldcustdo.strip().lower()=="s":
        search=input("Please enter your keyword.\n")
        search=search.strip()
        medicines=open("medicines.txt", "r")
        for line in medicines:
            if line.strip()==() or line.strip()==(""):
                continue
            else:
                details=line.split(";")
            if search.strip() in details[0].lower() or search.strip() in details[0].capitalize():
                print("Name: "+details[0]+"\nCategory: "+details[7].capitalize()+"\nHalal Status: (Yes/No/Unknown)"+details[1]+"\nExpiration Date: "+details[2]+"\nVolume or Tablets: "+details[3]+"\nPrice: RM"+details[4]+"\nRemaining Stock: "+details[5]+"\n")
                next=input("Next match?\n[Y] Yes\n[N] No\n[X] Exit\n")
                if next.lower().strip()=="y":
                    continue
                elif next.lower().strip()=="n":
                    do2=input("What would you like to do?\n[O] Order\n[X] Exit\n")
                    if do2.lower().strip()=="o":
                        howmany=input("What is the quantity of your purchase?\n")
                        try:
                            howmany=int(howmany)
                        except ValueError:
                            print("Error: Value enter not a number.")
                            CMenu(username,password)
                        howmany=str(howmany)
                        try:
                            orders=open("orders.txt","a")
                        except:
                            print("Requested file does not exist. Please check and try again.")
                            CMenu(username,password)
                        customers=open("customers.txt","r")
                        for lines in customers:
                            if lines.strip()==() or lines.strip()==(""):
                                continue
                            else:
                                contte=lines.split(";")
                            if username==contte[0]:
                                orders.write("\n0;"+contte[4]+";"+details[6]+";"+howmany+";")
                                print("Your order has been recorded.\n")
                                orders.close()
                            else:
                                continue
                            change=False
                            while change==False:
                                update_stock=open("medicines.txt","r")
                                buffer=open("buffer.txt","w")
                                buffer.write(update_stock.read())
                                update_stock.close()
                                clear=open("medicines.txt","w").close()
                                update=open("medicines.txt","a")
                                buffer.close()
                                buffer_1=open("buffer.txt","r+")
                                for lines in buffer_1:
                                    if lines.strip()==() or lines.strip()==(""):
                                        continue
                                    else:
                                        content=lines.split(";")
                                    if content[6]==details[6]:
                                        left=int(details[5])-int(howmany)
                                        left=str(left)
                                        combineee=("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+left+";"+content[6]+";"+content[7]+";")
                                        update.write(str(combineee))
                                    else:
                                        update.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                change=True
                            update.close()
                            CMenu(username,password)
                    elif do2.lower().strip()=="x":
                        CMenu(username,password)
                        break
                    else:
                        print("Invalid input. Returning to menu...\n")
                        CMenu(username,password)
                        break
                elif next.lower().strip()=="x":
                    CMenu(username,password)
                    break
                else:
                    continue
        print("No more matches. Returning...\n")
        CMenu(username,password)
    elif oldcustdo.strip().lower()=="a": 
        customers=open("customers.txt", "r")
        for lines in customers:
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
            if username==content[0]:
                print("\nUsername: "+content[0]+"\nPassword: "+content[1]+"\nEmail Address: "+content[2]+"\nPostal Address: "+content[3]+"\nContact Information: +60"+content[5]+"\nGender: "+content[6]+"\nDate of Birth: "+content[7]+"\n")
            else:
                continue
        changeopt=input("What would you like to change?\n[U] Username\n[P] Password\n[M] Email address\n[A] Postal address\n[C] Contact Number\n[G] Gender\n[D] Date of Birth\n[X] Exit\n")
        if changeopt.lower().strip()=="u":  #Proceed to change username
            can1=False
            can2=False
            change=False
            while can1==False: #Make sure the old username exists
                oldname=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your existing username: ")
                customers=open("customers.txt","r")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if oldname==content[0]:
                        can1=True
                        break
                    elif oldname.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
            customers.seek(0,0)
            while can2==False: #Make sure the new username is not taken
                newname=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new username: ")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if newname==content[0]:
                        can1=False
                        break
                    elif newname.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of usernames
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if oldname==content[0]:
                        customers_1.write("\n"+newname+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="p": #Proceed to change password
            can1=False
            can2=False
            change=False
            while can1==False: #Make sure the input exists and is correct
                oldpass=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your current password: ")
                customers=open("customers.txt","r")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if username==content[0] and oldpass==content[1]:
                        can1=True
                        break
                    elif oldpass.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
            customers.seek(0,0)
            while can2==False: #Make sure the passwords do not overlap
                newpass=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new password: ")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if newpass==oldpass:
                        print("You cannot change to a password previously linked to this account. Please try again.\n")
                        can1=False
                        break
                    elif newpass.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of passwords
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if username==content[0] and oldpass==content[1]:
                        customers_1.write("\n"+content[0]+";"+newpass+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="m": #Proceed to change email address
            can1=False
            can2=False
            change=False
            while can1==False: #Make sure the old email exists
                oldmail=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your current email address: ")
                customers=open("customers.txt","r")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if oldmail==content[2]:
                        can1=True
                        break
                    elif oldmail.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
            customers.seek(0,0)
            while can2==False: #Make sure the new email is not used
                newmail=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new email address: ")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if newmail==content[2]:
                        can1=False
                        break
                    elif newmail.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of email
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if oldmail==content[2]:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+newmail+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="a": #Proceed to change address
            can2=False
            change=False
            customers=open("customers.txt","r")
            customers.seek(0,0)
            while can2==False: #Make sure new address is different from old address
                newaddress=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new address: ")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if username==content[0] and newaddress==content[3]:
                        print("This address is already in use. Please enter a different address.\n")
                        break
                    elif newaddress.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of address
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if username==content[0] and password==content[1]:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+newaddress+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="c": #Proceed to change contact number
            can2=False
            change=False
            customers=open("customers.txt","r")
            customers.seek(0,0)
            while can2==False: #Make sure one number only appear once
                new_number=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new contact number: +60")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if new_number==content[5]:
                        print("This number is already in use. Please enter a different number.\n")
                        break
                    elif new_number.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of number
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if username==content[0] and password==content[1]:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+new_number+";"+content[6]+";"+content[7]+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="g": #Proceed to change gender information
            can2=False
            change=False
            customers=open("customers.txt","r")
            customers.seek(0,0)
            while can2==False: #Make sure new gender is different from old gender
                new_gen=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new gender (Male/Female/Others): ")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=line.split(";")
                    if username==content[0] and new_gen==content[6]:
                        print("You cannot change to the same gender. Please try again.\n")
                        break
                    elif new_gen.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of gender
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if username==content[0] and password==content[1]:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+new_gen+";"+content[7]+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="d": #Proceed to change date of birth
            can2=False
            change=False
            customers=open("customers.txt","r")
            customers.seek(0,0)
            while can2==False: #Make sure new date is different from old date
                new_date=input("\nNote: You can enter [X] to exit to menu.\nPlease enter your new date of birth (dd/mm/yyyy): ")
                for line in customers:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        pass    
                    content=line.split(";")
                    if new_date==content[7]:
                        print("You cannot change to the same date of birth. Returning to menu...\n")
                        break
                    elif new_date.lower().strip()=="x":
                        CMenu(username,password)
                    else:
                        continue
                can2=True
            customers.seek(0,0)
            while change==False: #Perform copying and replacing of birth date
                buffer=open("buffer.txt","w")
                buffer.write(customers.read())
                customers.close()
                clear=open("customers.txt","w").close()
                customers_1=open("customers.txt","a")
                buffer.close()
                buffer_1=open("buffer.txt","r+")
                for lines in buffer_1:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if username==content[0] and password==content[1]:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+new_date+";")
                    else:
                        customers_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                change=True
            customers_1.close()
            CMenu(username,password)
        elif changeopt.lower().strip()=="x":
            print("\nReturning to menu...\n")
            CMenu(username,password)
        else:
            print("\nInvalid input. Returning to menu...\n")
            CMenu(username,password)
    elif oldcustdo.strip().lower()=="c":
        damn=0
        print("Cart for "+username+"\n")
        customers=open("customers.txt","r")
        for lines in customers:
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
            if username==content[0]:
                custcode=content[4]
                break
            else:
                continue
        customers.close()
        orders=open("orders.txt","r")
        for lines in orders:
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
            stat=content[0]
            amount=content[3]
            if content[1]==custcode:
                medicines=open("medicines.txt","r")
                medicode=content[2]
                for lines in medicines:
                    if lines.strip()==() or lines.strip()==(""):
                        continue
                    else:
                        content=lines.split(";")
                    if content[6]==medicode:
                        mediname=content[0]
                        halal=content[1]
                        expdate=content[2]
                        volmas=content[3]
                        price=content[4]
                        left=content[5]
                        amount=float(amount)
                        price=float(price)
                        total=amount*price
                        if stat=="0":
                            damn=damn+total
                            total=str(total)
                            amount=int(amount)
                            print("Amount :",amount,"\nMedicine name: "+mediname+"\nHalal status (Yes/No/Unknown): "+halal+"\nExpiration date: "+expdate+"\nVolume or mass: "+volmas+"\nRemaining stock: "+left+"\nPrice for one: RM",price,"\nTotal price: RM"+total+"\n")
                            break
                    else:
                        continue
                    medicines.close()
            else:
                continue
        customers.close()
        orders.close()
        if damn!=0:
            print("\nEnd of cart.")
            print("Total: RM",damn)
            pay=input("Would you like to pay now?\n[Y] Yes\n[N] No\n")
            if pay.lower().strip()=="y":
                print("Bank transfer completed, thank you for using OPMS.")
                print("\n\nExiting to main menu...")
                Main()
            elif pay.lower().strip()=="n":
                print("Returning to menu...\n")
                CMenu(username,password)
            else:
                print("Invalid input. Returning to menu...\n")
                CMenu(username,password)
        else:
            print("You do not have any orders. Returning to menu...\n")
            CMenu(username,password)
    elif oldcustdo.strip().lower()=="x":
        Main()
    else:
        CMenu(username,password)

def New(): #Menu for new customers
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()
    newcustdo=input("What would you like to do?\n[R] Register\n[V] View catalog\n[S] Search medicine\n[X] Exit\n")
    if newcustdo.strip().lower()=="r":
        try:
            adding=open("customers.txt","r")
        except:
            print("The requested file does not exist, please check and try again.")
        success=False
        error=True
        while error==True:    
            newcust1=input("Please enter your desired username or [X] to exit to menu:\n")
            if newcust1.strip().lower()=="x":
                print("Exiting to menu...\n")
                New()
                break
            else:
                newcust2=input("Please enter your desired password:\n")
                newcust3=input("Please confirm your password (at least 8 characters):\n")
                newcust4=input("Please enter your email address:\n")
                newcust5=input("Please enter your mailing address:\n")
                newcust6=input("Please enter your contact number:\n+60")
                newcust7=input("PLease enter your gender information (Male/Female/Others):\n")
                newcust8=input("Please enter your date of birth (dd/mm/yyyy):\n")
            if newcust2!=newcust3:
                print("Passwords do not match. Please check your password and try again.\n")
                continue
            elif newcust1=="" or newcust2=="" or newcust3=="" or newcust4=="" or newcust5=="" or newcust6=="" or newcust7=="" or newcust8=="" or len(newcust6)<8 or len(newcust8)<8:
                print("You cannot use this information.")
                continue
            elif len(newcust2)<8 or len(newcust3)<8:
                print("You cannot use this information. Password should be at least 8 characters long.")
                continue
            else:
                print("\nUsername: "+newcust1+"\nPassword: "+newcust2+"\nEmail address: "+newcust4+"\nMailing address: "+newcust5+"\nContact :"+newcust6+"\nGender: "+newcust7.capitalize()+"\nBirthdate: "+newcust8+"\n")
            for lines in adding:
                if lines.strip()==() or lines.strip()==(""):
                    continue
                else:
                    content=lines.split(";")
                if content[2]==newcust4:
                    print("Sorry, this email address is already in use.")
                    error=True
                elif content[0]==newcust1:
                    print("Sorry, this username is already in use.")
                    error=True
                else:
                    error=False
        while error==False:
            check=input("Is this the correct information?\n[Y] Yes\n[N] No\n")
            while success==False:
                if check.lower().strip()=="y":
                    check2=open("customers.txt","r")
                    biggest=0
                    for lines in check2:
                        if lines.strip()==() or lines.strip()==(""):
                            continue
                        else:
                            content=lines.split(";")
                        biggest=int(biggest)
                        maybe=content[4]
                        maybe=int(maybe)
                        if maybe>biggest:
                            biggest=maybe
                        else:
                            continue
                    check2.close()
                    biggest=str(biggest+1)
                    adding=open("customers.txt","a+")
                    adding.write("\n"+newcust1+";"+newcust2+";"+newcust4+";"+newcust5+";"+biggest+";"+newcust6+";"+newcust7.capitalize()+";"+newcust8+";")
                    success=True
                elif check.lower().strip()=="n":
                    continue
                else:
                    print("Invalid input. Please try again.\n")
                    New()
            adding.close()
            break
        while success==True:
            print("You may now log in using your username and password.\n")
            Main()
    elif newcustdo.strip().lower()=="v":
        medicines=open("medicines.txt","r")
        for lines in medicines:
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
            print("Name: "+content[0]+"\nCategory: "+content[7].capitalize()+"\nHalal Status (Yes/No/Unknown): "+content[1]+"\nExpiration Date: "+content[2]+"\nVolume or Tablets: "+content[3]+"\nPrice: RM"+content[4]+"\nRemaining Stock: "+content[5]+"\n")
        print("Note: You need to create an account to place an order. Please create an account before making an order.\n")
        New()
    elif newcustdo.strip().lower()=="s":
        search=input("Please enter your keyword.\n")
        search=search.strip()
        medicines=open("medicines.txt", "r")
        for line in medicines:
            if line.strip()==() or line.strip()==(""):
                continue
            else:
                details=line.split(";")
            if search.strip() in details[0].lower() or search.strip() in details[0].capitalize():
                print("\nMatches found!\nName: "+details[0]+"\nCategory: "+details[7].capitalize()+"\nHalal Status (Yes/No/Unknown): "+details[1]+"\nExpiration Date: "+details[2]+"\nVolume or Tablets: "+details[3]+"\nPrice: RM"+details[4]+"\nRemaining Stock: "+details[5]+"\n")
                next=input("Next match?\n[Y] Yes\n[N] No\n[X] Exit\n")
                if next.lower().strip()=="y":
                    continue
                elif next.lower().strip()=="n":
                    do2=input("What would you like to do?\n[O] Order\n[X] Exit\n")
                    if do2.lower().strip()=="o":
                        print("\nSorry, you need to create an account to place an order. Please create an account before making an order.\n")
                        New()
                    elif do2.lower().strip()=="x":
                        New()
                elif next.lower().strip()=="x":
                    New()
                else:
                    continue
        print("No more matches. Returning...\n")
        New()
    elif newcustdo.strip().lower()=="x":
        print("Exiting to the main menu...\n")
        Main()
    else:
        print("Invalid input. Returning to menu...\n")
        Main()

def Login(user): #Universal login page for all user types
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()
    
    if user==1:
        try:
            list=open("admins.txt", "r")
        except:
            print("File failed to read, please check again.\n")
    elif user==2:
        try:
            list=open("customers.txt", "r")
        except:
            print("File failed to read, please check again.\n")
    else:
        print ("This is getting weird.\n")
    username=input("To exit, press [X], otherwise please enter the following details.\nUsername: ")
    password=input("Password: ")
    login=False
    for line in list:
        if line.strip()==() or line.strip()==(""):
            continue
        else:
            content=line.split(";")
        if username.strip()==content[0] and password.strip()==content[1]:
            login=True
            break
        elif username.strip().lower()=="x" or password.strip().lower()=="x":
            Main()
        else:
            continue
    list.close()
    if login:
        print("Login successful.\n")
        if user==1:
            AMenu()
        elif user==2:
            CMenu(username,password)
        else:
            print("Unknown error, please try again or press [X] to exit.\n")
    else:
        print("Login unsuccessfully, please try again or press [X] to exit.\n")
        Login(user)

def AMenu(): #If successfully login as admin, this page will display to ask what the admin wants to do
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()

    AWant=input("What would you like to check?\n[I] Inventory\n[O] Orders\n[X] Logout\n")
    if AWant=="I" or AWant=="i":
        AMed()
    elif AWant=="O" or AWant=="o":
        AOrder()
    elif AWant=="X" or AWant=="x":
        Main()
    else:
        tryOrNo=input("Press R to try again or any other key to exit to main menu.\n")
        if tryOrNo=="R" or tryOrNo=="r":
            AMenu()
        else:
            Main()

def AMed(): #Medicine view for admin
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()
    
    look=input("What would you like to do?\n[A] Add\n[S] Search\n[V] View all\n[X] Exit\n")
    if look.strip().lower()=="a":
        try:
            adding=open("medicines.txt","r")
        except:
            print("The requested file does not exist, please check and try again.")
        success=False
        adding=adding.readlines()[-1]
        while success==False:    
            add1=input("Please enter the name of the medicine:\n")
            add2=input("Please enter the halal status of the medicine (Yes/No/Unknown):\n")
            add3=input("Please enter the expiration date of the medicine (dd/mm/yyyy):\n")
            add4=input("Please enter the volume or mass of the medicine (in g or ml or capsules):\n")
            add5=input("Please enter the price of the medicine:\nRM")
            add6=input("Please enter the remaining stock of the medicine:\n")
            add7=input("Please enter the category of the medicine (Tablets/Liquids/Capsules):\n")
            if add1.lower().strip()=="x" or add2.lower().strip()=="x" or add3.lower().strip()=="x" or add4.lower().strip()=="x" or add5.lower().strip()=="x" or add6.lower().strip()=="x" or add7.lower().strip()=="x":
                print("You cannot use this information.")
                AMed()
                break
            elif add1.lower().strip()=="" or add2.lower().strip()=="" or add3.lower().strip()=="" or add4.lower().strip()=="" or add5.lower().strip()=="" or add6.lower().strip()=="" or add7.lower().strip()=="":
                print("You cannot use this information.")
                AMed()
                break
            print("\nName: "+add1.capitalize()+"\nCategory: "+add7+"\nHalal Status (Yes/No/Unknown): "+add1+"\nExpiration Date: "+add3+"\nVolume or Tablets: "+add4+"\nPrice: RM"+add5+"\nRemaining Stock: "+add6)
            check=input("Is this the correct information?\n[Y] Yes\n[N] No\n")
            another=open("medicines.txt","r")
            biggest=0
            for lines in another:
                if lines.strip()==() or lines.strip()==(""):
                    continue
                else:
                    content=lines.split(";")
                biggest=int(biggest)
                maybe=content[6]
                maybe=int(maybe)
                if maybe>biggest:
                    biggest=maybe
                else:
                    continue
            another.close()
            biggest=biggest+1
            if check.lower().strip()=="y":
                adding=open("medicines.txt","a+") #0name;1halal or not;2exp date;3volume or mass or tablets;4price;5stock left;6code number;7category;
                combine=str("\n"+add1+";"+add2+";"+add3+";"+add4+";"+add5+";"+add6+";"+str(biggest)+";"+add7+";")
                adding.write(combine)
                success=True
            elif check.lower().strip()=="n":
                continue
        adding.close()
        print("Medicine added successfully!\nExiting to admin menu now...\n")
        AMenu()
    elif look.strip().lower()=="s":
        search=input("Please enter your keyword or type [X] 3 times to exit\n")
        search=search.strip()
        medicines=open("medicines.txt", "r+")
        lines=int(len(medicines.readlines()))
        medicines.seek(0,0)
        position=0
        if search.lower().strip()=="xxx":
            AMed()
        else:
            for line in medicines:
                if line.strip()==() or line.strip()==(""):
                    continue
                else:
                    details=line.split(";")
                if search in details[0].lower() or search in details[0].capitalize() or search in details[7].lower():
                    print("\nName: "+details[0]+"\nCategory: "+details[7]+"\nHalal Status (Yes/No/Unknown): "+details[1]+"\nExpiration Date: "+details[2]+"\nVolume or Tablets: "+details[3]+"\nPrice: RM"+details[4]+"\nRemaining Stock: "+details[5])
                    next=input("Next match?\n[Y] Yes\n[N] No\n[X] Exit\n") #Quantity Remaining Stock
                    medname=details[0]
                    medcode=details[6]
                    if next.lower().strip()=="y":
                        continue
                    elif next.lower().strip()=="n":
                        do2=input("What would you like to do?\n[E] Edit\n[D] Delete\n[X] Exit\n")
                        if do2.lower().strip()=="e":
                            changeopt=input("What would you like to change?\n[M] Medicine Name\n[H] Halal Status\n[E] Expiration Date\n[Q] Quantity\n[P] Price\n[R] Remaining Stock\n[C] Category\n[X] Exit\n")
                            if changeopt.lower().strip()=="m":  #Change medicine name
                                medname_new=input("Please enter new medicine name: ")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+medname_new+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nMedicine name change was successful. Returning to menu...\n")
                                AMed()
                            elif changeopt.lower().strip()=="h":  #Change medicine name
                                halal_new=input("Yes/No/Unknown\nPlease enter new status: ")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+content[0]+";"+halal_new+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nHalal status was changed successfully. Returning to menu...\n")
                                AMed()
                            elif changeopt.lower().strip()=="e":  #Change medicine name
                                exp_new=input("Please enter new expiration date (dd/mm/yyyy):\n")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+exp_new+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nExpiration date was changed successfully. Returning to menu...\n")
                                AMed()
                            elif changeopt.lower().strip()=="q":  #Change medicine name
                                quantity_new=input("Please enter new quantity (in g or ml or capsules): ")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+quantity_new+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nQuantity of this medicine was changed successfully. Returning to menu...\n")
                                AMed()
                            elif changeopt.lower().strip()=="p":  #Change medicine name
                                price_new=input("Please enter new price for this medicine:\n")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+price_new+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nPricing for this medicine was changed successfully. Returning to menu...\n")
                                AMed()
                            elif changeopt.lower().strip()=="r":  #Change medicine name
                                stock_new=input("Please enter the new stock amount: ")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+stock_new+";"+content[6]+";"+content[7]+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nStock amount was changed successfully. Returning to menu...\n")
                                AMed()
                            elif changeopt.lower().strip()=="c":  #Change medicine name
                                cate_new=input("What is the new category (Tablets/Liquids/Capsules): ")
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+cate_new+";")
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nCategory for this medicine was changed successfully. Returning to menu...\n")
                                AMed()
                            else:
                                print("No more matches found. Exiting to menu.")
                                AMed()
                        elif do2.lower().strip()=="d":
                            confirm=input("Confirm delete?\n[Y] Yes\n[N] No\n")
                            if confirm.lower().strip()=="y":
                                change=False
                                while change==False:
                                    medicines=open("medicines.txt","r")
                                    buffer=open("buffer.txt","w")
                                    buffer.write(medicines.read())
                                    medicines.close()
                                    clear=open("medicines.txt","w").close()
                                    medicines_1=open("medicines.txt","a")
                                    buffer.close()
                                    buffer_1=open("buffer.txt","r+")
                                    for lines in buffer_1:
                                        if lines.strip()==() or lines.strip()==(""):
                                            continue
                                        else:
                                            content=lines.split(";")
                                        if medname==content[0] and medcode==content[6]:
                                            continue
                                        else:
                                            medicines_1.write("\n"+content[0]+";"+content[1]+";"+content[2]+";"+content[3]+";"+content[4]+";"+content[5]+";"+content[6]+";"+content[7]+";")
                                    change=True
                                medicines_1.close()
                                print("\nMedicine deleted successfully. Returning to menu...\n")
                                AMed()
                            elif confirm.lower().strip()=="n":
                                print("Deletion was aborted. Returning to menu...\n")
                                AMed()
                            else:
                                print("Invalid input. Return to menu...\n")
                        elif do2.lower().strip()=="x":
                            print("Returning to menu...\n")
                            AMed()
                        else:
                            print("Invalid input. Returning to menu...\n")
                            AMed()
                    elif next.lower().strip()=="x":
                        AMed()
                    else:
                        continue
            else:
                print("No match found. Returning to menu...\n")
                AMed()          
    elif look.strip().lower()=="x":
        AMenu()   
    elif look.strip().lower()=="v":
        medicines=open("medicines.txt","r")
        for lines in medicines:
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
            print("\nName: "+content[0]+"\nCategory: "+content[7].capitalize()+"\nHalal Status (Yes/No/Unknown): "+content[1]+"\nExpiration Date: "+content[2]+"\nVolume or Tablets: "+content[3]+"\nPrice: RM"+content[4]+"\nRemaining Stock: "+content[5]+"\n")
        print("These are all the available medicines.\n")
        AMed()
    else:
        print("Invalid input. Returning to menu...\n")
        AMed()

def AOrder(): #Order view for admin
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()
    
    order=input("Would you like to search for an order or to list all?\n[S] Search\n[A] View all\n[X] Exit\n")
    if order.strip().lower()=="s":
        print("\nHere is a list of all the availble inputs for customer usename.\n")
        customers=open("customers.txt","r")
        customer=customers.readlines()
        for lines in customer:
            content=lines.split(";")
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                print(content[0])
        search=input("Please enter full username of customer.\n")
        search=search.strip()
        list=[]
        customers.seek(0,0)
        for lines in customers:
            item=lines.split(";")
            if search==item[0]:
                custcode=item[4]
                break
            elif lines.strip()==() or lines.strip()==(""):
                continue   
            else:
                continue
        try:
            custcode=str(int(custcode))
        except UnboundLocalError:
            print("There has been an error")
            AOrder()
        customers.close()
        orders=open("orders.txt","r")
        for line in orders:
            details=line.split(";")
            if custcode==details[1]:
                list.append(line)
                continue
            elif lines.strip()==() or lines.strip()==(""):
                continue
            else:
                continue
        orders.close()  
        medicines=open("medicines.txt","r")
        for things in list:
            thing=things.split(";")
            amount=thing[3]
            medicines.seek(0,0)
            for lines in medicines:
                content=lines.split(";")
                if lines.strip()==() or lines.strip()==(""):
                    continue   
                elif thing[1]==custcode:
                    medcode=thing[2]
                    if medcode==content[6]:
                        print("\nName: "+content[0]+"\nHalal Status (Yes/No/Unknown): "+content[1]+"\nExpiration Date: "+content[2]+"\nVolume or mass: "+content[3]+"\nPrice: RM"+content[4]+"\nAmount: "+amount+"\n")
                        continue
                    else:
                        continue
                else:
                    continue
        print("\nNote: If the list is empty, or nothing is showing, then there is no order from this customer.\n")
        medicines.close()
        AOrder()
    elif order.strip().lower()=="a":
        biggest=0
        list1=[]
        customers=open("customers.txt","r")
        for lines in customers: #Write all customer and their ID to a list and get largest customer code
            if lines.strip()==() or lines.strip()==(""):
                continue
            else:
                content=lines.split(";")
                list1.append(content[0]+";"+content[4]+";")
                biggest=int(biggest)
                maybe=content[4]
                maybe=int(maybe)
                if maybe>biggest:
                    biggest=maybe
                else:
                    continue
        customers.close()
        lines=len(list1)
        for stuff in list1: 
            stu=stuff.split(";")
            custname=stu[0]
            custcode=stu[1]
            list=[]
            try:
                custcode=str(int(custcode))
            except UnboundLocalError:
                print("There has been an error")
                AOrder()
            customers.close()
            orders=open("orders.txt","r")
            for line in orders:
                if line==() or line==(""):
                    continue   
                else:
                    details=line.split(";")
                    if custcode==str(details[1]):
                        list.append(line)
                        continue
                    else:
                        continue
            orders.close()
            medicines=open("medicines.txt","r")
            print("Order list for customer: "+custname)
            for things in list:
                thing=things.split(";")
                amount=thing[3]
                medicines.seek(0,0)
                for lines in medicines:
                    if lines.strip()==() or lines.strip()==(""):
                        continue   
                    else:
                        content=lines.split(";")
                        if thing[1]==custcode:
                            medcode=thing[2]
                            if medcode==content[6]:
                                print("\nName: "+content[0]+"\nHalal Status (Yes/No/Unknown): "+content[1]+"\nExpiration Date: "+content[2]+"\nVolume or mass: "+content[3]+"\nPrice: RM"+content[4]+"\nAmount: "+amount)
                                continue
                            else:
                                continue
                        else:
                            continue
            print("\nNote: If the list is empty, or nothing is showing, then there is no order from this customer.")
            print("= = = = = = = = = = = = = = =")
            medicines.close()
        AOrder()
    elif order.strip().lower()=="x":
        AMenu()
    else:
        print("Invalid input. Please try again.")
        AMenu()

def Main(): #Welcome page asking type for their user type
    proper1=open("admins.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper1:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper1.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("admins.txt","w").close()
    proper1=open("admins.txt","a")
    for lines in buffer:
        proper1.write(lines)
    proper1.close()
    buffer.close()

    proper2=open("customers.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper2:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper2.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("customers.txt","w").close()
    proper2=open("customers.txt","a")
    for lines in buffer:
        proper2.write(lines)
    proper2.close()
    buffer.close()

    proper3=open("medicines.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper3:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper3.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("medicines.txt","w").close()
    proper3=open("medicines.txt","a")
    for lines in buffer:
        proper3.write(lines)
    proper3.close()
    buffer.close()

    proper4=open("orders.txt","r")
    clear=open("buffer.txt","w").close()
    buffer=open("buffer.txt","a")
    for lines in proper4:
        if lines=="\n" or lines==():
            continue
        else:
            buffer.write(lines)
    proper4.close()
    buffer.close()
    buffer=open("buffer.txt","r")
    clear=open("orders.txt","w").close()
    proper4=open("orders.txt","a")
    for lines in buffer:
        proper4.write(lines)
    proper4.close()
    buffer.close()

    clear=open("buffer.txt","w").close()
    
    type=input("\nWelcome to Online Pharmacy Management System (OPMS) by OCEAN Sdn Bhd\nWhat type of user are you?\n[A] Admin\n[N] New Customer\n[R] Registered Customer\n")
    type=type.strip()
    if type.lower().strip()=="a":
        user=1
        Login(user)
    elif type.lower().strip()=="r":
        user=2
        Login(user)
    elif type.lower().strip()=="n":
        New()
    else:  
        print("Invalid input. Please try again.")
        Main()

Main()
