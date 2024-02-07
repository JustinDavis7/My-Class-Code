# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.23
Justin Davis

LAB: Word frequencies

Write a program that reads a list of words. 
Then, the program outputs those words and their frequencies. 

"""
user_input = input()
tokens = user_input.split()

for i in tokens:
    print(i, tokens.count(i))