# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.6
Justin Davis

Many documents use a specific format for a person's name. Write a program whose input is: 
firstName middleName lastName
and whose output is:
lastName, firstInitial.middleInitial. 
"""

name = input()
name = name.split()
if len(name) == 3:

    print('{}, {}.{}.'.format(name[2], name[0][0], name[1][0]))
else:
    print('{}, {}.'.format(name[1], name[0][0]))
