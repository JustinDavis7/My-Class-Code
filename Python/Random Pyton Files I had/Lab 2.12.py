# -*- coding: utf-8 -*-
"""
Lab 2.12
CS 161
Justin Davis
Partner : Nick Mcclain

This is a temporary script file.
"""
userInt = int(input('Enter integer (0 - 155):\n'))

# FIXME (1): Finish reading other items into variables, then output the four values on a single line separated by a space
userFloat = float(input('Enter float:\n'))
userChar = (input('Enter character:\n'))
userString = (input('Enter string:\n'))


print(userInt, userFloat, userChar, userString)
# FIXME (2): Output the four values in reverse
print(userString, userChar, userFloat, userInt)
# FIXME (3): Convert the integer to a characer, and output that character
print(userInt, 'converted to a character is', chr(userInt))