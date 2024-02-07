# -*- coding: utf-8 -*-
"""

Week 5 In Class Assignment
CS 161
Justin Davis
Partner : 

This is a temporary script file.
"""

number = ""
for i in range(1,10):
    number = number + str(i)    
    num = int(number)
    print(num, '* 8 +', i, '=', num*8+i)
    
number = ""
for i in range(1,10):
    number = number + str(i)    
    num = int(number)
    print(num, '* 9 +', i, '=', num*9+i+1)
    
number = ""
for i in range(9,1, -1):
    number = number + str(i)    
    num = int(number)
    print(num, '* 9 +', i-2, '=', num*9+i-2)
    
number = ""
for i in range(1,10):
    number = number + str(1)
    num = int(number)
    print(num, '*', num,  '=', num*num)
