"""
CS 162

Array Lab

Justin Davis
Partner: Tyler
"""

from adts.iarray import IArray

class Array(IArray):
    def __init__(self, size):
        self._items = [None] * size  # Makes a blank space so any data type can be used here (string, int, ect.)

    def clone(instance):
        if not isinstance(instance, Array):
            raise Exception

        copy = Array(len(instance))
        for i in range(len(instance)):
            copy[i] = instance[i]
        return copy

    def __getitem__(self, index):
        if index >= len(self._items) or index <= -len(self._items):
            raise IndexError
        return self._items[index]

    def __setitem__(self, index, data):
        if index >= len(self._items) or index <= -len(self._items):
            raise IndexError
        self._items[index] = data

    def __len__(self) -> int:
        return len(self._items)

    def resize(self, new_size):
        new_items = [None] * new_size

        smaller_size = len(self._items) if len(self._items) < new_size else new_size

        for i in range(smaller_size):
            new_items[i] = self._items[i]

        self._items = new_items

    def __eq__(self, other) -> bool:
        if type(other) != type(self):
            return False

        if len(self._items) != len(other):
            return False

        for i in range(len(self._items)):
            if self._items[i] != other[i]:
                return False

        return True

    def __iter__(self):
        for i in range(len(self._items)):
            yield self._items[i]

    def __delitem__(self, index):
        if index >= len(self._items) or index <= -len(self._items):
            raise IndexError

        new_items = [None] * (len(self._items)-1)
        counter = 0
        self._items[index] = None
        for i in range(len(self._items)):
            if self._items[i] is None:
                continue
            new_items[counter] = self._items[i]
            counter += 1

        self._items = new_items

    def __contains__(self, item) -> bool:
        return item in self._items
