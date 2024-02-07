# -*- coding: utf-8 -*-
"""

Lab 5.15
CS 161
Justin Davis
Partner: Wyatt - Marcos

This is a temporary script file.
"""


arrow_base_height = int(input('Enter arrow base height:\n'))

arrow_base_width = int(input('Enter arrow base width:\n'))

arrow_head_width = int(input('Enter arrow head width:\n'))

while arrow_head_width <= arrow_base_width:
    arrow_head_width = int(input('Enter arrow head width:\n'))

print('')

i = 0
while i < arrow_base_height:
    j = 0 
    while j < arrow_base_width:
        print('*', end='')
        j += 1
    print()
    i += 1

i = 0
while i < arrow_head_width:
    j = arrow_head_width - i
    while j > 0:
        print('*', end='')
        j -= 1
    print()
    i += 1