# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.19
Justin Davis

LAB: Varied amount of input data

Statistics are often calculated with varying amounts of input data. 
Write a program that takes any number of integers as input, and outputs the average and max.
"""

user_input = input()
tokens = user_input.split()
average = 0
i = 0
while i < len(tokens):
    tokens[i] = int(tokens[i])
    average += tokens[i]
    i += 1
average = average/i
print(int(average), max(tokens))