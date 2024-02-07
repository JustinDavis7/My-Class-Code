from abc import ABC, abstractmethod


class Account(ABC):
    def __init__(self, first_name, last_name, type, phone, email, pin, balance):
        self.first_name = first_name
        self.last_name = last_name
        self.type = type
        self.phone = phone
        self.email = email
        self.pin = pin
        self.balance = balance

    def deposit(self, deposit_amount):
        balance = int(self.balance)
        balance += deposit_amount
        self.balance = str(balance)

    def withdrawal(self, withdraw_amount):
        if (int(self.balance) - withdraw_amount) < 0:
            raise Exception('Not enough funds in account to withdraw.')
        else:
            balance = int(self.balance)
            balance -= withdraw_amount
            self.balance = balance

    def get_first_name(self):
        return self.first_name

    def get_last_name(self):
        return self.last_name

    def get_phone(self):
        return self.phone

    def get_email(self):
        return self.email

    def get_pin(self):
        return self.pin

    def get_type(self):
        return self.type

    def get_balance(self):
        return self.balance
