# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.21
Justin Davis

LAB: Middle item

Given a sorted list of integers, output the middle integer. 
Assume the number of integers is always odd.
"""
import math

user_input = input()
tokens = user_input.split()
i = 0
while i < len(tokens):
    tokens[i] = int(tokens[i])
    i += 1
if i > 9:
    print('Too many inputs')
else:
    print(tokens[math.ceil(i/2)-1])