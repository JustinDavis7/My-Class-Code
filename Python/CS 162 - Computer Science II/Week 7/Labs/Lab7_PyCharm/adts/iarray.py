"""
CS 162

Array Lab

Justin Davis
Partner: Tyler
"""

import abc


class IArray(abc.ABC):

    """ Constructor
        Usage:  array = Array(10)
        @:param size the desired size of the Array
        @:param instance an optional Array instance to deep copy data from.
            Should only copy the smaller of size or len(instance) items
        @:return none
    """
    @abc.abstractmethod
    def __init__(self, size):
        pass

    """ Clone the array
        Usage:  array = Array.clone(instance)
        @:param instance an Array instance to deep copy data from.
        @:return none
    """
    @staticmethod
    def clone(instance):
        pass

    """ Bracket operator for getting an item
        Usage: val = array[0]
        @:param index the desired index
        @:return the item at the index
        @:raises IndexError if the index is out of bounds
    """
    @abc.abstractmethod
    def __getitem__(self, index):
        pass

    """ Bracket operator for setting an item
        Usage: array[index] = val
        @:param index the desired index to set
        @:param data the desired data to set at index
        @:raises IndexError if the index is out of bounds
        @:return none
    """
    @abc.abstractmethod
    def __setitem__(self, index, data):
        pass

    """ len operator for setting an item
        Usage: for i in range(len(array))
        @:return the length of the Array
    """
    @abc.abstractmethod
    def __len__(self) -> int:
        pass

    """ Resize an Array
        Usage: array.resize(5)
        @:param new_size the desired new size
        @:return none
    """
    @abc.abstractmethod
    def resize(self, new_size):
        pass

    """ Equality operator ==
        Usage: array1 == array2
        @:param other the instance to compare self to
        @:return true if the arrays are equal (deep check)
    """
    @abc.abstractmethod
    def __eq__(self, other) -> bool:
        pass

    """ Iterator operator
        Usage: for item in array:
        @:return yields the item at index
    """
    @abc.abstractmethod
    def __iter__(self):
        pass

    """ Delete an item in the array. Copies the array contents from index + 1 down
        to fill the gap caused by deleting the item and shrinks the array size down by one
        Usage: del array[0]
        @:param index the desired index to delete
        @:return none
    """
    @abc.abstractmethod
    def __delitem__(self, index):
        pass

    """ Contains operator (in)
        Usage: if 3 in array:
        @:param item the desired item to check whether it's in the array
        @:return true if the array contains the item
    """
    @abc.abstractmethod
    def __contains__(self, item) -> bool:
        pass
