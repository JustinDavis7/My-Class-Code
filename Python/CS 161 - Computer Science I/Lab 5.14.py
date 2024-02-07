# -*- coding: utf-8 -*-
"""

Lab 5.14
CS 161
Justin Davis
Partner: Wyatt - Marcos

This is a temporary script file.
"""

triangle_char = input('Enter a character:\n')
triangle_height = int(input('Enter triangle height:\n'))
print('')

i = 0
while i < triangle_height:
    j = 0
    while j < i + 1:
        print(triangle_char, end=' ')
        j += 1
    print()
    i += 1
