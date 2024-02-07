# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.22
Justin Davis

LAB: Elements in a range

Write a program that first gets a list of integers from input. 
That list is followed by two more integers representing lower and upper bounds of a range. 
Your program should output all integers from the list that are within that range 
(inclusive of the bounds). 
"""
user_input = input()
tokens1 = user_input.split()
i = 0
while i < len(tokens1):
    tokens1[i] = int(tokens1[i])
    i += 1
    
user_input = input()
tokens2 = user_input.split()
i = 0
while i < len(tokens2):
    tokens2[i] = int(tokens2[i])
    i += 1
 
numbers = []
for i in tokens1:
    if i >= tokens2[0] and i <= tokens2[1]:
        numbers.append(i)

for i in numbers:
    print(i, end=' ')