# Lucas Cordova

from abc import ABC, abstractmethod

class AbstractAccount(ABC):
    def __init__(self, amount):
        self._balance = amount
    
    def deposit(self, amount):
        if amount >= 10000:
            raise Exception("Unable to deposit more than $10,000")
        self._balance += amount
        
    
    def withdraw(self, amount):
        if self._balance - amount < 0.00:
            raise Exception("Overdraw attempt")
        self._balance -= amount
    
    def get_balance(self):
        return self._balance
    
    @abstractmethod
    def calculate_interest(self):
        pass