import csv
from savings import Savings
from checking import Checking
import matplotlib.pyplot as plt


def selection_sort(accounts):
    for i in range(len(accounts) - 1):
        index_smallest = i
        for j in range(i + 1, len(accounts)):
            if accounts[j].get_last_name() < accounts[index_smallest].get_last_name():
                index_smallest = j

        temp = accounts[i]
        accounts[i] = accounts[index_smallest]
        accounts[index_smallest] = temp


class Bank:
    def __init__(self, c_file, s_file):
        self._c_accounts = []
        self._s_accounts = []
        self._c_file = c_file
        self._s_file = s_file
        self._load_c_data()
        self._load_s_data()
        self.display_accounts()

    def open_account(self, account, type):
        if type == '1':
            self._c_accounts.append(account)
            self.save_c_data()
        elif type == '2':
            self._s_accounts.append(account)
            self.save_s_data()

    def close_account(self, account, type):
        if type == '1':
            found = False
            for i in range(len(self._c_accounts)):
                if self._c_accounts[i].get_phone() == account.get_phone():
                    del self._c_accounts[i]
                    found = True
                    self.save_c_data()
                    break
            if not found:
                raise Exception('Account not found')
        if type == '2':
            found = False
            for i in range(len(self._s_accounts)):
                if self._s_accounts[i].get_phone() == account.get_phone():
                    del self._s_accounts[i]
                    found = True
                    self.save_s_data()
                    break
            if not found:
                raise Exception('Account not found')

    def change_first_name(self, account, name):
        account.first_name = name
        self.save_c_data()
        self.save_s_data()

    def change_last_name(self, account, name):
        account.last_name = name
        self.save_c_data()
        self.save_s_data()

    def change_phone(self, account, phone):
        account.phone = phone
        self.save_c_data()
        self.save_s_data()

    def change_email(self, account, email):
        account.email = email
        self.save_c_data()
        self.save_s_data()

    def change_pin(self, account, pin):
        account.pin = pin
        self.save_c_data()
        self.save_s_data()

    def _load_c_data(self):
        self._c_accounts.clear()
        with open(self._c_file) as file:
            for item in csv.reader(file, delimiter=',', skipinitialspace=True):
                self._c_accounts.append(Checking(item[0], item[1], item[2], item[3], item[4], item[5], item[6]))
            selection_sort(self._c_accounts)
            self.save_c_data()

    def _load_s_data(self):
        self._s_accounts.clear()
        with open(self._s_file) as file:
            for item in csv.reader(file, delimiter=',', skipinitialspace=True):
                self._s_accounts.append(Savings(item[0], item[1], item[2], item[3], item[4], item[5], item[6]))
            selection_sort(self._s_accounts)
            self.save_s_data()

    def display_accounts(self):
        selection_sort(self._c_accounts)
        self.save_c_data()
        selection_sort(self._s_accounts)
        self.save_s_data()
        print('\n------Checking Accounts------\n')
        print('{:<12}{:<13}{:<14}{:<15}{:<23}{:<7}{:<12}'.format('First Name', 'Last Name', 'Account Type', 'Phone',
                                                                 'Email', 'Pin', 'Balance'))
        for item in self._c_accounts:
            print(
                f'{item.get_first_name():<11} {item.get_last_name():<11} | {item.get_type():>6}      | {item.get_phone():<12} | {item.get_email():<20} | {item.get_pin():<4} | {item.get_balance():<10}')

        print('\n------Savings Accounts------\n')
        print('{:<12}{:<13}{:<14}{:<15}{:<23}{:<7}{:<12}'.format('First Name', 'Last Name', 'Account Type', 'Phone',
                                                                 'Email', 'Pin', 'Balance'))
        for item in self._s_accounts:
            print(
                f'{item.get_first_name():<11} {item.get_last_name():<11} | {item.get_type():>6}      | {item.get_phone():<12} | {item.get_email():<20} | {item.get_pin():<4} | {item.get_balance():<10}')

    def save_c_data(self):
        with open(self._c_file, 'w') as file:
            for account in self._c_accounts:
                file.write(
                    f'{account.first_name},{account.last_name},{account.type},{account.phone},{account.email},{account.pin},{account.balance}\n')

    def save_s_data(self):
        with open(self._s_file, 'w') as file:
            for account in self._s_accounts:
                file.write(
                    f'{account.first_name},{account.last_name},{account.type},{account.phone},{account.email},{account.pin},{account.balance}\n')

    def find_account_by_phone(self, phone, type, pin):
        if type == '1':
            for account in self._c_accounts:
                account_phone = account.get_phone()
                account_pin = account.get_pin()
                if account_phone != phone:
                    pass
                elif account_pin != pin:
                    pass
                else:
                    return account
            raise Exception('No such account exist.')
        elif type == '2':
            for account in self._s_accounts:
                account_phone = account.get_phone()
                account_pin = account.get_pin()
                if account_phone != phone:
                    pass
                elif account_pin != pin:
                    pass
                else:
                    return account
            raise Exception('No such account exist.')
        else:
            raise Exception(f'We do not support an account of type {type}. We only have accounts of types: (1) '
                            'Checking (2) Savings.')

    def plot_account_totals(self):
        checking_totals = 0
        savings_totals = 0

        arrow_properties = {
            'facecolor': 'White',
            'shrink': 0.1,
            'headlength': 10,
            'width': 2
        }

        for item in self._c_accounts:
            checking_totals += int(item.get_balance())
        for item in self._s_accounts:
            savings_totals += int(item.get_balance())
        plt.bar('1', checking_totals, color='Red', label='Checking Accounts')
        plt.bar('2', savings_totals, color='Blue', label='Savings Accounts')

        plt.annotate(f'${checking_totals} in all checking accounts', xy=(0, checking_totals),
                     xytext=(-0.44, checking_totals * .5), arrowprops=arrow_properties)

        plt.annotate(f'${savings_totals} in all savings accounts', xy=(1, savings_totals),
                     xytext=(0.6, savings_totals * .5), arrowprops=arrow_properties)

        plt.title('Account Totals by Type')
        plt.ylabel('Totals in Dollars($)')
        plt.xlabel('Account Types')

        plt.show()
