# -*- coding: utf-8 -*-
"""
Lab 3.12
CS 161
Justin Davis
Partner : Chris Coady

This is a temporary script file.
""" 
import math

# Dictionary of paint colors and cost per gallon
paint_colors = {
   'red': 35,
   'blue': 25,
   'green': 23
}

# FIXME (1): Prompt user to input wall's width
# Calculate and output wall area
wall_height = float(input('Enter wall height (feet):\n'))
wall_width = float(input('Enter wall width (feet):\n'))
wall_area = int(wall_height * wall_width)
print('Wall area: {} square feet'.format(wall_area))
   
# FIXME (2): Calculate and output the amount of paint in gallons needed to paint the wall
paint_needed = (wall_height*wall_width)/350.0
print('Paint needed: {:f}'.format(paint_needed), 'gallons')

# FIXME (3): Calculate and output the number of 1 gallon cans needed to paint the wall, rounded up to nearest integer
print('Cans needed:', math.ceil(paint_needed), 'can(s)\n')
# FIXME (4): Calculate and output the total cost of paint can needed depending on color
user_choice = input('Choose a color to paint the wall:\n')
print('Cost of purchasing {} paint:'.format(user_choice), '${}'.format(paint_colors[user_choice] * math.ceil(paint_needed)))