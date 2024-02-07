# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.7
Justin Davis

Write a program whose input is a string which contains a character and a phrase, 
and whose output indicates the number of times the character appears in the phrase. 
"""

user_input = input()
char = user_input[0:1]
phrase = user_input[2:]
print(phrase.count(char))
