# -*- coding: utf-8 -*-
"""

CS 161
Lab 7.9
Justin Davis

A palindrome is a word or a phrase that is the same when read both forward and backward. 
Examples are: "bob," "sees," or "never odd or even" (ignoring spaces). 
Write a program whose input is a word or phrase, and that outputs whether the input is a palindrome.
"""
user_input = input()
user_input_no_ws = user_input.split()
seperator = ''
user_input_no_ws = seperator.join(user_input_no_ws)
i = 0
j = len(user_input_no_ws) - 1 
pal = ''
while i != j:
    if user_input_no_ws[i] == user_input_no_ws[j]:
        i += 1
        if i < j:
            j -= 1
        else:
            break
    else:
        pal = 'false'
        break

if user_input_no_ws[i] == user_input_no_ws[j]:    
    print(user_input, 'is a palindrome')
else:
    print(user_input, 'is not a palindrome')

