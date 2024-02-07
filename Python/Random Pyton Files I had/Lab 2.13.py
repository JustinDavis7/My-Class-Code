# -*- coding: utf-8 -*-
"""
Lab 2.13
CS 161
Justin Davis
Partner : Nick Mcclain

This is a temporary script file.
"""
lemonJuiceCups = float(input('Enter amount of lemon juice (in cups):\n'))

# FIXME (1): Finish reading other items into variables, then output the three ingrdients
waterCups = float(input('Enter amount of water (in cups):\n'))
agaveCups = float(input('Enter amount of agave nectar (in cups):\n'))
servingsMade = float(input('How many servings does this make?\n\n'))

print('Lemonade ingredients - yields', servingsMade, 'servings')
print(lemonJuiceCups, 'cup(s) lemon juice')
print(waterCups, 'cup(s) water')
print(agaveCups, 'cup(s) agave nectar\n')

# FIXME (2): Prompt user for desired number of servings. Convert and output the ingredients
servingsToMake = float(input('How many servings would you like to make?\n\n'))
print('Lemonade ingredients - yields', servingsToMake, 'servings')
multiplier = servingsToMake / servingsMade
lemonJuiceCups = lemonJuiceCups * multiplier
waterCups = waterCups * multiplier
agaveCups = agaveCups * multiplier
servingsMade = servingsMade * multiplier

print(lemonJuiceCups, 'cup(s) lemon juice')
print(waterCups, 'cup(s) water')
print(agaveCups, 'cup(s) agave nectar\n')

# FIXME (3): Convert and output the ingredients from (2) to gallons   
print('Lemonade ingredients - yields', servingsToMake, 'servings')
lemonJuiceCups = lemonJuiceCups/16
waterCups = waterCups/16
agaveCups = agaveCups/16
servingsMade = servingsMade/16

print(lemonJuiceCups, 'gallon(s) lemon juice')
print(waterCups, 'gallon(s) water')
print(agaveCups, 'gallon(s) agave nectar')