# Lucas Cordova


from abstract_account import AbstractAccount

class Checking(AbstractAccount):
    def __init__(self, amount):
        super().__init__(amount)
        
    def calculate_interest(self):
        self._balance *= 1.05