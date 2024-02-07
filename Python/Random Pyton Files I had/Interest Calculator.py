# -*- coding: utf-8 -*-
"""
In Class Example
CS 161
Justin Davis

This is a temporary script file.
"""
import math

principal_amt = float(input('Enter principal amount: '))
print()

interest_rate = float(input('Enter annual interest % rate: '))
interest_rate = interest_rate / 100
print()

compound_per_year = int(input('Enter the number of times per year interest is compounded: '))
print()

years = int(input('Enter years that pass: '))
print()

total = principal_amt * math.pow(((1+(interest_rate / compound_per_year))), (compound_per_year * years))
print('Total after', years, 'years:', total)