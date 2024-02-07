"""
CS 162
Searching Lab - Video game search engine

Justin Davis
Partner: Moshe, Marcos
"""
import time


class Stopwatch():
    def __init__(self):
        self.start_time = time.time()

    def elapsed(self):
        difference = time.time() - self.start_time
        return difference

