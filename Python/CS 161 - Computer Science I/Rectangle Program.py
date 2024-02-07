# -*- coding: utf-8 -*-
"""
CS 161

Justin Davis
"""
from RectangleFunctions import printDimensions, rect_area
length = int(input('Enter the length of a rectangle:'))
width = int(input('Enter the width of a rectangle:'))

printDimensions(length, width)
print('The area of the rectangle is ', rect_area(length, width))
from RectangleFunctions import printDimensions, rect_area