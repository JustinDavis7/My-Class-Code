# -*- coding: utf-8 -*-
"""
CS 162
Lab 2.8 Exception handling to detect input string vs. integer

Justin Davis
"""
# Split input into 2 parts: name and age
parts = input().split()
name = parts[0]
while name != '-1':
    # FIXME: The following line will throw ValueError exception.
    #        Insert try/except blocks to catch the exception.
    try:
        age = int(parts[1]) + 1
    except ValueError:
        age = 0   
    print('{} {}'.format(name, age))
    
    # Get next line
    parts = input().split()
    name = parts[0]