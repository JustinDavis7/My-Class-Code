# -*- coding: utf-8 -*-
"""
Lab 3.11
CS 161
Justin Davis
Partner : Chris Coady

This is a temporary script file.
"""
# FIXME (1): Finish reading another word and an integer into variables. 
# Output all the values on a single line
fav_color = input('Enter favorite color:\n')
animal_name = input('Enter pet\'s name:\n')
user_number = int(input('Enter a number:\n'))

print('You entered:', fav_color, animal_name, user_number)

# FIXME (2): Output two password options
password1 = ('{}_{}'.format(fav_color, animal_name))
password2 = ('{}{}{}'.format(user_number, fav_color, user_number))
print('\nFirst password:', password1)
print('Second password:', password2)


# FIXME (3): Output the length of the two password options
print('\nNumber of characters in {}:'.format(password1), len(password1))
print('Number of characters in {}:'.format(password2), len(password2))