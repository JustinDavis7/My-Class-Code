# -*- coding: utf-8 -*-
"""
Created on Sat Mar 14 20:23:18 2020

@author: Justin
"""
from Square import area, perimeter, print_dimensions
length = int(input('Enter the length of a side of a square: '))
print_dimensions(length)
print('The are of the square is', area(length))