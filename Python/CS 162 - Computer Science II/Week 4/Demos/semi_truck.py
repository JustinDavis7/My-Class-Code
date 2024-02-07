# -*- coding: utf-8 -*-
"""
CS 162

Coding from a UML diagram for vehicles

Justin Davis
"""
from automobile import Automobile

class SemiTruck(Automobile):
    def __init__(self, vin, make, model, color, num_wheels, energy_type, number_of_doors, number_of_airbags):
        Automobile.__init__(self, vin, make, model, color, num_wheels, energy_type, number_of_doors, number_of_airbags)
        print('SemiTruck constructor')
        
    def blow_horn(self, number_of_times):
        print(f'SemiTruck: blowing the horn {number_of_times} times')
        
    def cruise_control(self, speed):
        print(f'SemiTruck: Cruising at {speed}')
