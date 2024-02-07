# -*- coding: utf-8 -*-
"""

This program takes in a value for the hole's par, as well as a value for the players shot count.
From there it minuses the shot count from the par. If the shot score is negative, it's
not a positive score, but a bogey. If it's postitive then it's a good score. The 
calculation is backwards from the way golf is really scored.


@ author Justin Davis
@version CS 161 Lab 4, 1/31/2020
Partner : T.J.

This is a temporary script file.
""" 
hole_par = int(input('What is the hole\'s par?'))
shots_taken = int(input('\nInput the number of shots for the player:'))
shot_score = hole_par - shots_taken

if shot_score > 3:
    print('That\'s just a lie...')
elif shot_score < -3:
    print('Bad hole')
elif shot_score == 3:
    print('Albatross')
elif shot_score == 2:
    print('Eagle')
elif shot_score == 1:
    print('Birdie')
elif shot_score == -1:
    print('Bogey')
elif shot_score == -2:
    print('Double Bogey')
elif shot_score == -3:
    print('Triple Bogey')
else:
    print('Par')