# -*- coding: utf-8 -*-
"""
CS 162

Using code from a UML diagram for vehicles

Justin Davis
"""
from passenger_car import PassengerCar
from semi_truck import SemiTruck
from automobile import Automobile

car = PassengerCar(123456, 'BMW', '535i xDrive', 'White', 4, 'Gas', 4, 6)

car.start()
car.accelerate(50)
car.blow_horn(3)

automobile = Automobile(123456, 'BMW', 'i3', 'White/Back', 4, 'Electric', 4, 4)
#There is no def for blow_horn in automobile, so it isn't getting called and can't do anything
automobile.blow_horn(3)

#semi = SemiTruck(6549884, 'Volvo', 'Hell', 'Blue', 18, 'Diesel', 2, 1)
