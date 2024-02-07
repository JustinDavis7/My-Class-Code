# Lucas Cordova

from abstract_account import AbstractAccount

class Saving(AbstractAccount):
    def __init__(self, amount):
        super().__init__(amount)
        
    def calculate_interest(self):
        self._balance *= 1.10