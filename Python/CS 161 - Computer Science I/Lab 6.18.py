# -*- coding: utf-8 -*-
"""

CS 161
Lab 6.18
Justin Davis
Partner : Rylie

This is a temporary script file.
"""
def driving_cost(driven, mpg, dollars_gallon):
    your_value = (driven/mpg) * dollars_gallon
    print('{:.2f}'.format(your_value))
    return your_value

if __name__ == '__main__':
    mpg = float(input())
    dollars_gallon = float(input())
    driven = 10
    driving_cost(driven, mpg, dollars_gallon)
    driven = 50
    driving_cost(driven, mpg, dollars_gallon)
    driven = 400
    driving_cost(driven, mpg, dollars_gallon)
