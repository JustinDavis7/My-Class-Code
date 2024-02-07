"""
CS 162
Lab 4 Geometric Shapes Inherited

Justin Davis
"""
from abc import ABC


class GeometricShape(ABC):
    def __init__(self, color='green', filled=True):
        self._color = color
        self._filled = filled

    def get_color(self):
        return self._color

    def set_color(self, new_color: str):
        self._color = new_color

    def is_filled(self):
        return self._filled

    def set_filled(self, filled: bool):
        self._filled = filled

    def __str__(self):
        return f'color: {self._color} and filled: {bool(self._filled)}'
