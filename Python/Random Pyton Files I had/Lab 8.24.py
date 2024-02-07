# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.24
Justin Davis

LAB: Contact list

A contact list is a place where you can store a specific contact with other associated 
information such as a phone number, email address, birthday, etc. Write a program that 
first takes in word pairs that consist of a name and a phone number (both strings). 
That list is followed by a name, and your program should output the phone number associated 
with that name.
"""
user_input = input()
tokens = user_input.split()
user_input = input()
index = tokens.index(user_input)
print(tokens[index+1])