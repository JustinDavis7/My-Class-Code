from account import Account


class Checking(Account):
    def __init__(self, first_name, last_name, type, phone, email, pin, balance):
        super().__init__(first_name, last_name, type, phone, email, pin, balance)