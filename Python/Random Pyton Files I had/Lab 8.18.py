# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.18
Justin Davis

LAB: Warm up: People's weights (Lists)
"""
# FIXME (1): Prompt for four weights. Add all weights to a list. Output list.
weights = []
weight1 = float(input('Enter weight 1:'))
weight2 = float(input('\nEnter weight 2:'))
weight3 = float(input('\nEnter weight 3:'))
weight4 = float(input('\nEnter weight 4:\n'))

weights.append(weight1)
weights.append(weight2)
weights.append(weight3)
weights.append(weight4)

print('Weights:', weights)
# FIXME (2): Output average of weights.
print('\nAverage weight: %.2f' % (sum(weights)/4))
# FIXME (3): Output max weight from list.
print('Max weight: %.2f' % (max(weights)))
# FIXME (4): Prompt the user for a list index and output that weight in pounds and kilograms.
user_input = int(input('\nEnter a list location (1 - 4):'))
print('\nWeight in pounds: %.2f' % (weights[user_input-1]))
print('Weight in kilograms: %.2f' % (weights[user_input-1]/2.2))
# FIXME (5): Sort the list and output it.
print('\nSorted list:', sorted(weights))