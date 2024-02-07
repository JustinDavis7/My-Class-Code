# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.11
Justin Davis

Write a program that reads a character, then reads in a list of words. 
The output of the program is every word in the list that contains the character at least once. 
Assume at least one word in the list will contain the given character. 
"""

user_char = input()
user_phrase = input()
token = user_phrase.split()
string_array = []
string = ''
i = 0

while i < len(token):
    if user_char in token[i]:
        string_array.append(token[i])
    i += 1       
i = 1
string += string_array[0]
while i < len(string_array):
    string += '\n' + string_array[i]
    i += 1
print(string)