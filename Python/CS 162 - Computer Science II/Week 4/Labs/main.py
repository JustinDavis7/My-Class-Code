"""
CS 162
Lab 4 Geometric Shapes Inherited

Justin Davis
"""
from circle import Circle
circle = Circle(4,'red',0)
print(circle.get_diameter())
print(circle.get_circumference())
print(circle.get_area())
print(circle.__str__())