# -*- coding: utf-8 -*-
"""
Lab .
CS 161
Justin Davis
Partner : 

This is a temporary script file.
"""
user_age_years = int(input('enter your age in years:\n'))

user_age_days = user_age_years  * 365
user_age_minutes = (user_age_days*24)*60
user_age_seconds = user_age_minutes  * 60
user_heart_bpm = user_age_minutes * 72
user_sneeze_life = user_age_days * 4.5

print('You are at least {} days old.'.format(user_age_days))
print('You are at least {} minutes old.'.format(user_age_minutes))
print('You are at least {} seconds old.'.format(user_age_seconds))
print('Your heart has beated around {} times in your life.'.format(user_heart_bpm))
print('You have sneezed about {} times in your life.'.format(user_sneeze_life))