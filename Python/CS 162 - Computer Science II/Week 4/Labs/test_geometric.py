"""
CS 162
Lab 4 Geometric Shapes Inherited

Justin Davis
"""
import unittest
from circle import Circle


class TestShapes(unittest.TestCase):

    def test_diameter_nondefault(self):
        # Arrange
        circle = Circle(4, 'red', 0)

        # Act
        diameter = circle.get_diameter()

        # Assert
        self.assertEqual(8, diameter, 'The diameter was not calculated correctly')

    def test_color_default(self):
        # Arrange
        circle = Circle(4)

        # Act
        color = circle.get_color()

        # Assert
        self.assertEqual(color, 'green')

    def test_color_nondefault(self):
        # Arrange
        circle = Circle(4, 'red', 0)

        # Act
        color = circle.get_color()

        # Assert
        self.assertEqual(color, 'red')

    def test_filled_default(self):
        # Arrange
        circle = Circle(4)

        # Act
        filled = circle.is_filled()

        # Assert
        self.assertTrue(filled)

    def test_filled_nondefault(self):
        # Arrange
        circle = Circle(4, 'red', 0)

        # Act
        filled = circle.is_filled()

        # Assert
        self.assertFalse(filled)

    def test_area(self):
        # Arrange
        circle = Circle(4, 'red', 0)

        # Act
        area = circle.get_area()

        # Assert
        self.assertAlmostEqual(area, 50.27, 2)

    def test_circumference(self):
        # Arrange
        circle = Circle(4, 'red', 0)

        # Act
        circumference = circle.get_circumference()

        # Assert
        self.assertAlmostEqual(circumference, 25.13, 2)
