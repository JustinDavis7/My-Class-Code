# -*- coding: utf-8 -*-
"""

CS 161
Justin Davis

Assignment description :
Write a program using Spyder that asks a day number and prints the day name (a string).
Assume the days of the week are numbered 0,1,2,3,4,5,6 from Sunday to Saturday. 
Submit a .py file on Moodle.

This is a temporary script file.
""" 
week_days = {
        '0' : 'Sunday',
        '1' : 'Monday',
        '2' : 'Tuesday',
        '3' : 'Wednesday',
        '4' : 'Thursday',
        '5' : 'Friday',
        '6' : 'Saturday'}

day_number = int(input('Enter the day number 1(Sunday)-7(Saturday):'))
if 0 < day_number < 8:
    print('The', str(day_number), 'day is', week_days[str(day_number - 1)])
else:
    print('\n\nThere\'s only 7 days in a week and that\'s not one of them...')