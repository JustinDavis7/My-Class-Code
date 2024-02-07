# -*- coding: utf-8 -*-
"""
CS 162

Coding from a UML diagram for vehicles

Justin Davis
"""
from vehicle import Vehicle
from abc import ABC, abstractmethod

class Automobile(ABC):
    def __init__(self, vin, make, model, color, num_wheels, energy_type, number_of_doors, number_of_airbags):
        Vehicle.__init__(self, vin, make, model, color, num_wheels, energy_type)
#This works a little different and only if there is one parent        
#        super().__init__(vin, make, model, color, num_wheels, energy_type)
        self.number_of_doors = number_of_doors
        self.number_of_airbags = number_of_airbags
        print('Automobile constructor')
        
    @abstractmethod
    def cruise_control(self,speed):
        pass
    
    @abstractmethod    
    def blow_horn(self, number_of_times):
        pass