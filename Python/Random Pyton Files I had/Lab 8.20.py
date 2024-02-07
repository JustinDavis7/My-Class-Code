# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.20
Justin Davis

LAB: Filter and sort a list

Write a program that gets a list of integers from input, and outputs non-negative 
integers in ascending order (lowest to highest). 
"""

user_input = input()
tokens = user_input.split()
even_numbers = []
i = 0
while i < len(tokens):
    if int(tokens[i]) >= 0:
        even_numbers.append(int(tokens[i]))
    i += 1
even_numbers = sorted(even_numbers)    
for i in even_numbers:
    print(i, end=' ')
    