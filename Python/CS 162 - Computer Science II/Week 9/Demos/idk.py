import time


class Stopwatch():
    def __init__(self):
        self.start_time = time.time()

    def elapsed(self):
        difference = time.time() - self.start_time
        return difference

s = Stopwatch()

a, b = 1, 2
print(a, b)
a,b = b,a
print(a,b)
print(s.elapsed())