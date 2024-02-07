# -*- coding: utf-8 -*-
"""
CS 162

Justin Davis
Partner: Tyler Tran
"""
class Planes():
    def __init__(self, passengerCount = 1, wingSpan = 10, engineCount = 1, altitude = 0, speed = 0):
        self.passengerCount = passengerCount
        self.wingSpan = wingSpan
        self.engineCount = engineCount
        self.altitude = altitude
        self.speed = speed
   
    def __str__(self):
        return "Plane passenger count: {}, wingSpan(ft): {}, enigneCount: {}, current altitude: {}, current speed: {}\n"\
            .format(self.passengerCount, self.wingSpan, self.engineCount, self.altitude, self.speed)
    
    def setAltitude(self, altitude):
        self.altitude = altitude
        print(self.__str__())
        
    def increaseSpeed(self, speed):
        self.speed = speed
        print(self.__str__())
    
my_planes = [Planes() for x in range(5)]

for plane in my_planes:
    print('Plane:', plane)

my_planes[0].setAltitude(5000)
my_planes[0].increaseSpeed(500)