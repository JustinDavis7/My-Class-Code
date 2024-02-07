# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.8
Justin Davis

Mad Libs are activities that have a person provide various words, which are then used to complete 
a short story in unexpected (and hopefully funny) ways.
Write a program that takes a string and integer as input, and outputs a sentence using those items as below. 
The program repeats until the input string is quit. 
"""

user_input = input()
string = []
item = ''
while 'quit 0' not in user_input:   
    split = user_input.split()
    item = split[0]
    number = split[1]
    string.append(number + ' ' + item)
    user_input = input()

for x in string:
    print('Eating {} a day keeps the doctor away.'.format(x))
