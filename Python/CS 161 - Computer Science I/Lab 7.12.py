# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.12
Justin Davis
Partner Shane

This is a temporary script file.
"""
user_input = ''
while user_input != 'q':
    option = 'false'
    while option == 'false':
        user_input = input('Enter input string:\n')
        if user_input == 'q':
            break
        for i in user_input:
            if i == ',':
                option = 'true'
                break
        if i != ',':    
            print('Error: No comma in string.\n')
        else:        
            token = user_input.split(',')
            print('First word: {}\nSecond word: {}\n'.format(token[0].strip(),token[1].strip()))