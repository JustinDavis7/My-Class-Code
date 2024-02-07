"""
CS 162
Lab 4 Geometric Shapes Inherited

Justin Davis
"""
from geometric_shape import GeometricShape
import math


class Circle(GeometricShape):
    def __init__(self, radius: float, color='green', filled=True):
        super().__init__(color, filled)
        self._radius = radius

    def get_radius(self):
        return self._radius

    def set_radius(self, radius):
        self._radius = radius

    def get_area(self):
        return math.pi*(self._radius*self._radius)

    def get_circumference(self):
        return 2*(math.pi*self._radius)

    def get_diameter(self):
        return self._radius * 2

    def __str__(self):
        return f'The circle is: Circle with radius = {self._radius} ' + super().__str__()
