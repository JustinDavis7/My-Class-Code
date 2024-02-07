# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.25
Justin Davis

LAB: Replacement words

Write a program that replaces words in a sentence. The input begins with word replacement pairs
(original and replacement). The next line of input is the sentence where any word on the 
original list is replaced. 
"""
user_input = input()
tokens = user_input.split('  ')
tokens2 = []

#Needed to split the look for/replace value pairs for use
for i in tokens:
    tokens2 += i.split()

user_string = input()
tokens = user_string.split()

"""
The [::2] is used to jump over everyother index since the first value is the one to check for
and the second value is the replacement
"""
for j in tokens2[::2]:
    for i in tokens:
        if i == j:
            tokens[tokens.index(i)] = tokens2[tokens2.index(j)+1]
    
#Can't print list directly, so have to use indexes and print
for i in tokens:
    if tokens.index(i) == len(tokens) - 1:
        print(i)
    else:
        print(i, end=' ')            
