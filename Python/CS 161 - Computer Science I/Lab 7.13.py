# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.13
Justin Davis
Partner Shane

This is a temporary script file.
"""
title = input('Enter a title for the data:\n')
print('You entered:', title)
column1 = input('\nEnter the column 1 header:\n')
print('You entered: {}\n'.format(column1))
column2 = input('Enter the column 2 header:\n')
print('You entered: {}\n'.format(column2))

user_input = input('Enter a data point (-1 to stop input):\n')
user_string = []
user_int = []
i = 0
while user_input != '-1':
    for a in user_input:
        if a == ',':
            if user_input.count(',') > 1:
                print('Error: Too many commas in input.\n')
                user_input = input('Enter a data point (-1 to stop input):\n')
                break
            else:
                token = user_input.split(',')
                if token[1].strip().isdigit():
                    user_string.append(token[0].strip())
                    user_int.append(token[1].strip())
                    print('Data string:', user_string[i])
                    print('Data integer:', user_int[i])
                    print()
                    user_input = input('Enter a data point (-1 to stop input):\n')
                    i += 1
                    break
                else:
                    print('Error: Comma not followed by an integer.\n')
                    user_input = input('Enter a data point (-1 to stop input):\n')
                    break
    if a != ',':
        print('Error: No comma in string.\n')
        user_input = input('Enter a data point (-1 to stop input):\n')
       
print('{name:>33}'.format(name=title))
print('{name:20}|'.format(name=column1), end='')
print('{name:>23}'.format(name=column2))
print('--------------------------------------------')

for a in range(i):   
    print('{name:20}|'.format(name=user_string[a]), end='')
    print('{name:>23}'.format(name=user_int[a]))
    
for a in range(i):
    print('{name:>20} '.format(name=user_string[a]), end='')
    for b in range(int(user_int[a])):
        print('*', end='')
    print()