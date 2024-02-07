# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.10
Justin Davis

An acronym is a word formed from the initial letters of words in a set phrase. 
Write a program whose input is a phrase and whose output is an acronym of the input. 
If a word begins with a lower case letter, don't include that letter in the acronym. 
Assume there will be at least one upper case letter in the input. 
"""

user_input = input()
token = user_input.split()
acronym = ''
for i in token:
    if i.islower():
        token.remove(i)
for i in token:
    acronym += i[0]
print(acronym)