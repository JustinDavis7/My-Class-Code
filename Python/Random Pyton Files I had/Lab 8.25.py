# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.25
Justin Davis

LAB: Replacement words

Write a program that replaces words in a sentence. The input begins with word replacement pairs
(original and replacement). The next line of input is the sentence where any word on the 
original list is replaced. 
"""
user_input = input()
tokens = user_input.split('  ')

for i in tokens:
    tokens2 += i.split()

user_string = input()
i = 0
j = 0
while i < len(user_string):
    while j < len(tokens2):
        if user_string[i] == tokens2[j]:
            user_string[i] = tokens2[j]
            j += 1
    i += 1

            
print(user_string)