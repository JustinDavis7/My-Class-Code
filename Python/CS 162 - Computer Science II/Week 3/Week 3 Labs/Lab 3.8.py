# -*- coding: utf-8 -*-
"""
CS 162
Lab 3.8

Justin Davis
"""
input_file = input()
upper_bound = input() 
lower_bound = input()
file = open(input_file) 
my_list = file.readlines()
for i in my_list:
    i = i.strip('\n')
    if i >= upper_bound and i <= lower_bound:
        print(i)
file.close()