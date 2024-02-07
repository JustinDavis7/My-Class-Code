# -*- coding: utf-8 -*-
"""

CS 161
Lab 9 - Game
Justin Davis
Partner: Wyatt


"""
import random
def getRange():
    random.seed()
    user_range = input('Enter the range of values for the guessing game:')
    tokens = user_range.split()
    low = int(tokens[0])
    high = int(tokens[1])
    correct = random.randint(low, high)
    return correct, low, high

def guessCheck(user_guess, guess, correct):
    while user_guess != correct:
        if user_guess > high or user_guess < low:
            print('Out of range, try again')
        elif user_guess < correct:
            print('{} is too low'.format(user_guess))
            guess += 1
        elif user_guess > correct:
            print('{} is too high'.format(user_guess))
            guess += 1
        user_guess = int(input('Enter a guess between {} and {}:'.format(low, high)))
    print('{} is correct!'.format(user_guess))
    print('Total guesses was', guess)   

correct, low, high = getRange()
user_guess = int(input('Enter a guess between {} and {}:'.format(low, high)))
guesses = 1
guessCheck(user_guess, guesses, correct)