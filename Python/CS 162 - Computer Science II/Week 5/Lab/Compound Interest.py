"""
CS 162

Justin Davis
Partner: Jasper
"""


def value(p, i, n):
    if n == 0:
        return p
    else:
        return value(p * (1 + i), i, n - 1)


print(value(1000, .06, 10))
