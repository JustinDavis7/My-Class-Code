"""
CS 162

Array Lab

Justin Davis
Partner: Tyler
"""

import unittest

from adts.array import Array


class ArrayTest(unittest.TestCase):
    def setUp(self):
        self._array = Array(10)
        for i in range(len(self._array)):
            self._array[i] = i

    def test_len(self):
        size = len(self._array)
        self.assertTrue(10, size)

    def test_index_operators(self):
        # Arrange
        my_array = Array(5)

        # Act
        for i in range(len(my_array)):
            my_array[i] = i

        # Assert

        for i in range(len(my_array)):
            self.assertEqual(i, my_array[i])

    def test_clone(self):
        # Arrange & Act
        copy = self._array.clone()

        # Assert
        self.assertEqual(self._array, copy)

    def test_resize_should_be_size_five(self):
        # Arrange & Act
        self._array.resize(5)

        # Assert
        self.assertEqual(5, len(self._array))

    def test_resize_should_not_lose_data(self):
        # Arrange & Act
        self._array.resize(5)

        # Assert
        expected_sum = 10
        actual_sum = 0
        for i in range(len(self._array)):
            actual_sum += self._array[i]

        self.assertEqual(expected_sum, actual_sum)

    def test_resize_should_not_lose_data_when_resizing_larger(self):
        # Arrange & Act
        self._array.resize(15)

        # Assert
        expected_sum = 45
        actual_sum = 0
        for i in range(len(self._array)):
            if self._array[i] is not None:
                actual_sum += self._array[i]

        self.assertEqual(expected_sum, actual_sum)

    def test_eq_should_be_true(self):
        # Arrange
        array_2 = Array(10)
        for i in range(len(array_2)):
            array_2[i] = i

        # Act
        result = self._array == array_2

        # Assert
        self.assertTrue(result)

    def test_eq_should_be_false(self):
        # Arrange
        array_2 = Array(10)
        for i in range(len(array_2)):
            array_2[i] = -i

        # Act
        result = self._array == array_2

        # Assert
        self.assertFalse(result)

    def test_eq_should_be_false_for_other_type(self):
        # Arrange
        other = 'test'

        # Act
        result = self._array == other

        # Assert
        self.assertFalse(result)

    def test_iter(self):
        counter = 0
        for i in self._array:
            self.assertEqual(counter, i)
            counter += 1

    def test_del(self):
        # Arrange & Act
        del self._array[2]

        # Assert
        self.assertEqual(9, len(self._array))

    def test_del_index_in_array(self):
        # Arrange & Act
        del self._array[3]

        # Assert
        self.assertNotIn(3, self._array)

    def test_del_op_exception_should_raise_exception_on_boundary(self):
        with self.assertRaises(IndexError):
            del self._array[10]

    def test_del_op_exception_should_raise_exception_on_boundary_negative(self):
        with self.assertRaises(IndexError):
            del self._array[-10]

    def test_contains(self):
        does_contain = 5 in self._array

        self.assertTrue(does_contain)

    def test_index_op_get(self):
        index_one = self._array[1]

        self.assertEqual(index_one, 1)

    def test_index_op_get_exception(self):
        with self.assertRaises(IndexError):
            fail = self._array[100]

    def test_index_op_get_exception_on_boundary(self):
        with self.assertRaises(IndexError):
            fail = self._array[10]

    def test_index_op_get_exception_on_boundary_on_boundary_negative(self):
        with self.assertRaises(IndexError):
            fail = self._array[-10]

    def test_index_op_set(self):
        self._array[5] = 1321
        index_test = self._array[5]

        self.assertEqual(index_test, 1321)

    def test_index_op_set_exception(self):
        with self.assertRaises(IndexError):
            self._array[100] = 5

    def test_index_op_set_exception_should_raise_exception_on_boundary(self):
        with self.assertRaises(IndexError):
            self._array[10] = 5

    def test_index_op_set_exception_should_raise_exception_on_boundary_negative(self):
        with self.assertRaises(IndexError):
            self._array[-10] = 5


if __name__ == '__main__':
    unittest.main()
