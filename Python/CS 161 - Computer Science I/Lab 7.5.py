# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.5
Justin Davis

Forms often allow a user to enter an integer. Write a program that takes in a string representing 
an integer as input, and outputs yes if every character is a digit 0-9. 

"""
user_string = input()

if user_string.isdigit():
    print('yes')
else:
    print('no')