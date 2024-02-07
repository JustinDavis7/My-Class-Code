# -*- coding: utf-8 -*-
"""
Created on Mon Feb  3 13:05:58 2020

@author: Justin
"""
"""
user_score = 0
simon_pattern = input()
user_pattern  = input()
i = 0
j = len(simon_pattern)
while i < j:
    if user_pattern[i] == simon_pattern[i]:
        i += 1
        user_score += 1
    else:
        break
print('User score:', user_score)
"""
simon_pattern = 'RRGBRYYBGY'
user_pattern  = 'RRGBBRYBGY'
user_score = 0
i = 0
j = len(simon_pattern)
for user_pattern in simon_pattern:
    if user_pattern[i] != simon_pattern[i]:
        i += 1
        user_score += 1
    else:
        break
print('User score:', user_score)
