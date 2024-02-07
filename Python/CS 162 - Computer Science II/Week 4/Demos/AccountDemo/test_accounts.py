# Lucas Cordova

import unittest

from checking import Checking
from saving import Saving

class TestAccount(unittest.TestCase):
    
    # Sunny day case
    def test_checking_should_deposit_fifty_dollars(self):
        # Arrange - set up/ initializing
        checking = Checking(50.00)
        
        # Act - invoke 
        balance = checking.get_balance()
        
        
        # Assert - validate
        self.assertAlmostEqual(50.00, balance, 2)
        
    def test_deposit_should_add_fifty_dollars_to_balance(self):
        # Arrange
        saving = Saving(50.00)
        
        # Act
        saving.deposit(10.00)
        
        # Assert
        self.assertAlmostEqual(60.00, saving.get_balance(), 2)
        
    def test_withdraw_should_deduct_ten_dollars_from_balance(self):
        # Arrange - setup
        checking = Checking(50.00)
        
        # Act - invoke
        checking.withdraw(10.00)
        
        # Assert - validate the behavior/data
        self.assertAlmostEqual(40.00, checking.get_balance(), 2)
        
    
    def test_checking_calculate_interest_should_add_five_percent(self):
        # Arrange - setup
        checking = Checking(100.00)
        
        # Act - invoke
        checking.calculate_interest()
        
        # Assert - validate the behavior/data
        self.assertAlmostEqual(105.00, checking.get_balance(), 2)
        
    def test_saving_calculate_interest_should_add_five_percent(self):
        # Arrange - setup
        saving = Saving(100.00)
        
        # Act - invoke
        saving.calculate_interest()
        
        # Assert - validate the behavior/data
        self.assertAlmostEqual(110.00, saving.get_balance(), 2)
        
    
    def test_deposit_over_ten_thousand_should_raise_exception(self):
        
        # Arrange
        saving = Saving(100.00)
        
        # Act & Assert
        with self.assertRaises(Exception):
            saving.deposit(10000)
    
    def test_withdraw_overdraw_should_raise_exception(self):
        # Arrange - setup
        checking = Checking(100.00)
    
        # Act and Assert - invoke and validate
        with self.assertRaises(Exception):
            checking.withdraw(150.00)
        
        
        
        
        
        
        
    