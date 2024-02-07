# -*- coding: utf-8 -*-
"""
CS 161
Week 1 Lab 1.11 Car Value (Classes)
Justin Davis
"""
class Car:
    def __init__(self):
        self.model_year = 0
        # TODO: Declare purchase_price attribute
        self.purchase_price = 0
      
        self.current_value = 0

    def calc_current_value(self, current_year):
        depreciation_rate = 0.15
        # Car depreciation formula
        car_age = current_year - self.model_year
        self.current_value = round(self.purchase_price * (1 - depreciation_rate) ** car_age)
    
    # TODO: Define print_info() method to output model_year, purchase_price, and current_value
    def print_info(self):
        print('Car\'s information:\n   Model year: {}\n   Purchase price: {}\n   Current value: {}'.format(self.model_year, self.purchase_price, self.current_value))

if __name__ == "__main__":    
    year = int(input()) 
    price = int(input())
    current_year = int(input())
    
    my_car = Car()
    my_car.model_year = year
    my_car.purchase_price = price
    my_car.calc_current_value(current_year)
    my_car.print_info()
    