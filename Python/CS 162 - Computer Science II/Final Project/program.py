from bank import Bank
from checking import Checking
from savings import Savings


def get_input(message):
    response = input(message + '\n-->')
    return response


def is_type_valid(type):
    if type != ('1' or '2'):
        return False


def get_user_info():
    phone_pass = False
    pin_pass = False
    type_pass = False
    first_name = get_input('Enter first name: ')
    last_name = get_input('Enter last name:')

    while not type_pass:
        type = get_input('Enter account type, (1) Checking (2) Savings: ')
        if '1' == type or '2' == type:
            type_pass = True
        else:
            print('We only provide two types of accounts. Please pick one or find somewhere else that has '
                  'this mystical third type.')

    while not phone_pass:
        print('Please put in a full number ie.: xxx-xxx-xxxx.')
        phone = get_input('Enter phone number: ')
        if len(phone) == 12:
            phone_pass = True

    email = get_input('Enter email: ')

    while not pin_pass:
        pin = get_input('Enter your desired pin(4 numbers):')
        if len(pin) == 4:
            pin_pass = True
        else:
            print('Your pin can\'t be less or more than 4 digits')
    return first_name, last_name, type, phone, email, pin


def main():
    bank = Bank('checking_accounts.txt', 'savings_accounts.txt')

    menu = f'\n------Davis Banking inc.-------\nPlease choose an action:\n1. Open Account\n2. Close Account\n3. ' \
           f'Withdraw\n4. Deposit\n5. Find an Account\n6. Modify Account\n7. Show Account Totals\n8. Display ' \
           f'Accounts\n9. Quit '
    account_change_menu = 'Choose from the following for what you would like to do.\n(1) Change first name\n(2) ' \
                          'Change last name\n(3) Change phone number\n(4) Change email\n(5) Change pin\n(6) Return '

    choice = get_input(menu)

    while choice != '9':

        if choice == '1':
            first_name, last_name, type, phone, email, pin = get_user_info()

            initial_deposit = get_input('What is the initial deposit:')

            if type == '1':
                account = Checking(first_name, last_name, type, phone, email, pin, initial_deposit)
                bank.open_account(account, type)
                bank.save_c_data()
            else:
                account = Savings(first_name, last_name, type, phone, email, pin, initial_deposit)
                bank.open_account(account, type)
                bank.save_s_data()

        elif choice == '2':
            try:
                phone = get_input('Enter your phone number: ')
                pin = get_input('Please enter your pin:')
                type = get_input('Which type of account are you closing (1) Checking, or (2) Savings:')
                account = bank.find_account_by_phone(phone, type, pin)
                choice = get_input(f'Are you sure you wish to close your account (Y/N)?:')
                did_they_pass = False
                while not did_they_pass:
                    if choice == 'Y' or choice == 'y':
                        print('Closing account...')
                        bank.close_account(account, type)
                        print('Account terminated.')
                        did_they_pass = True
                    elif choice == 'N' or choice == 'n':
                        print('Try to be more decisive. This is serious you know that right?')
                        did_they_pass = True
                    else:
                        print('You blatantly ignored a simple Yes-No question, try again or I will just delete it '
                              'reguardless...')
                        did_they_pass = False
                        choice = get_input('Ok, try again, and pay attention this time. Do you want to delete your '
                                           'account (Y/N)?')
            except Exception as exception:
                print(exception)

        elif choice == '3':
            try:
                phone = get_input('Enter your phone number: ')
                pin = get_input('Please enter your pin:')
                type = get_input('Enter account type, (1) Checking (2) Savings: ')
                bank.find_account_by_phone(phone, type, pin)
                withdrawal = get_input('How much are you withdrawing:')
                if type == '1':
                    account = bank.find_account_by_phone(phone, type, pin)
                    account.withdrawal(int(withdrawal))
                    bank.save_c_data()
                elif type == '2':
                    account = bank.find_account_by_phone(phone, type, pin)
                    account.withdrawal(int(withdrawal))
                    bank.save_s_data()
                print('Your new account balance is:', account.balance)
            except Exception as exception:
                print(exception)

        elif choice == '4':
            try:
                phone = get_input('Enter your phone number: ')
                pin = get_input('Please enter your pin:')
                type = get_input('Enter account type, (1) Checking (2) Savings: ')
                bank.find_account_by_phone(phone, type, pin)
                deposit = get_input('How much are you depositing:')
                if type == '1':
                    account = bank.find_account_by_phone(phone, type, pin)
                    account.deposit(int(deposit))
                    bank.save_c_data()
                elif type == '2':
                    account = bank.find_account_by_phone(phone, type, pin)
                    account.deposit(int(deposit))
                    bank.save_s_data()
                print('Your new account balance is:', account.balance)
            except Exception as exception:
                print(exception)

        elif choice == '5':
            try:
                phone = get_input('Enter your phone number: ')
                pin = get_input('Please enter your pin:')
                type = get_input('Enter account type, (1) Checking (2) Savings: ')
                account = bank.find_account_by_phone(phone, type, pin)
                if type == '1':
                    type = 'checking'
                elif type == '2':
                    type = 'savings'
                print(
                    f'{account.first_name} {account.last_name} has ${account.balance} in {type}. Your contact info is as follows-\nPhone: {account.phone}\nEmail: {account.email}')
            except Exception as exception:
                print(exception)

        elif choice == '6':
            while choice != 6:
                try:
                    phone = get_input('Enter your phone number: ')
                    pin = get_input('Please enter your pin:')
                    type = get_input('Enter account type, (1) Checking (2) Savings: ')
                    account = bank.find_account_by_phone(phone, type, pin)
                    choice = int(get_input(account_change_menu))
                    while choice != 6:
                        if choice == 1:
                            new_name = get_input('Enter your new first name:')
                            bank.change_first_name(account, new_name)
                        elif choice == 2:
                            new_name = get_input('Enter your new last name:')
                            bank.change_last_name(account, new_name)
                        elif choice == 3:
                            new_phone = get_input('Enter your new phone number:')
                            bank.change_phone(account, new_phone)
                        elif choice == 4:
                            new_email = get_input('Enter your new email:')
                            bank.change_email(account, new_email)
                        elif choice == 5:
                            new_pin = get_input('Enter your new pin:')
                            bank.change_pin(account, new_pin)
                        choice = int(get_input(account_change_menu))

                except Exception as exception:
                    print(exception)

        elif choice == '7':
            print('Plotting account totals now...')
            bank.plot_account_totals()

        elif choice == '8':
            bank.display_accounts()

        else:
            print('Invalid choice. Please choose again.')

        choice = get_input(menu)
    print('Quit selected, your session has been terminated.')


main()
