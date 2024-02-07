# -*- coding: utf-8 -*-
"""
CS 162

Justin Davis
"""

class Car():
    def __init__(self, make = '', model = '', color = ''):
        self.make = make
        self.model = model
        self.color = color
    
    def __str__(self):
        return "car"
    
    def accelerate(self, speed):
        print('Accelerating to: {}'.format(speed))
        
    def stop(self):
        print('Car has stopped')
        
bmw = Car('BMW', 'i3', 'Panda')
bmw.accelerate(50)
bmw.stop()