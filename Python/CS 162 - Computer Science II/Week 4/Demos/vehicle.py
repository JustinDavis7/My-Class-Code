# -*- coding: utf-8 -*-
"""
CS 162

Coding from a UML diagram for vehicles

Justin Davis
"""
from abc import ABC, abstractmethod

class Vehicle():
    def __init__(self, vin, make, model, color, num_wheels, energy_type):
        self.vin = vin
        self.make = make
        self.model = model
        self.color = color
        self.num_wheels = num_wheels
        self.energy_type = energy_type
        print('Vehicle constructor')
        
    def start(self):
        print('Parent: vehicle started')
        
    def stop(self):
        print('Parent: vehicle stopped')
        
    def accelerate(self, speed):
        print(f'Parent: accelerating at {speed} speed')
        
    def brake(self):
        print('Parent: breaking')
    
    @abstractmethod    
    def blow_horn(self, number_of_times):
        pass