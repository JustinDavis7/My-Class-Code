# -*- coding: utf-8 -*-
"""
Created on Wed Feb  5 13:00:57 2020

@author: Justin
"""

tuition = 10000
double_tuit = 20000
counter = 0
while tuition < double_tuit:
    tuition *= 1.07
    counter += 1
print('\n\nIt will take', counter, 'years to double tuition.')
