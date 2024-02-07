# -*- coding: utf-8 -*-
"""
Lab 2 program
@authro: Justin Davis
@version CS 161 Lab 2, 1/20/2020
Partner: Nick Mcclain
"""
#needed for rounding down the division with floor so quarters doesn't equal 1.xx since coins can't be cut into pieces... easily, as well as
#not going from 1.6 to 2 magically adding .4 of a quater
import math

#gets the total amount of money in cents
cents = int(input('Please enter how much money you have in cents without a decimal (EX: .27 = 27): '))

#gets the number of quarters by dividing whats left of cents by 25 and rounds down with floor
quarters = math.floor((cents / 25))
#removes the number of quarters by their value from cents
cents = cents - (25 * quarters)

#gets the number of dimes by dividing whats left of cents by 10 and rounds down with floor
dimes = math.floor((cents / 10))
#removes the number of dimes by their value from cents
cents = cents - (10 * dimes)

#gets the number of nickels by dividing whats left of cents by 5 and rounds down with floor
nickels = math.floor((cents / 5))
#removes the number of nickels by their value from cents
cents = cents - (5 * nickels)

#gets the number of pennys from the remainder of cents after removal of quarters, dimes and nickels
pennys = cents

#prints out the title of the break down as well as the number of each denomination
print('Here is your change:\n', quarters, 'Quarter(s)\n', dimes, 'Dime(s)\n', nickels, 'Nickel(s)\n', pennys, 'Penny(s)')
