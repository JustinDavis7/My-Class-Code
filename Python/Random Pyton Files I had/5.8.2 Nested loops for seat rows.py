# -*- coding: utf-8 -*-
"""
Created on Mon Feb  3 13:23:47 2020

@author: Justin
"""

num_rows = int(input())
num_cols = int(input())

# Note 1: You will need to declare more variables
# Note 2: Place end=' ' at the end of your print statement to separate seats by spaces

for curr_row in range(1, num_rows + 1):
    curr_col_let = 'A'
    for curr_col in range(1, num_cols + 1):
        print('{}{}'.format(curr_row, curr_col_let), end=' ')
        curr_col_let = chr(ord(curr_col_let) + 1)

print()

num_rows = int(input())
num_cols = int(input())

i = 0
while i != num_rows:
    i += 1
    if num_rows != 0:
        if num_cols != 0:
            j = 0
            while j != num_cols:
                j += 1
            print('{}A {}B {}C'.format(i,i,i), end=' ')
print()