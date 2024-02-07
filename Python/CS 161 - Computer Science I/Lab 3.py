# -*- coding: utf-8 -*-
"""

Editing strings with different functions to become familiar with them.
Submitted late because neither of us know how to use a scroll wheel...

@author Justin Davis
@partner : Chris Coady
@version CS 161 Lab 3, 2/2/2020
""" 

#Get word from user and assign to word1
word1 = input('Input word one ')

#.upper() is used to capatalize, but the value isn't stored
print('word1 is now', word1.upper())
print('word1 is', word1)
print("word1 is still lowercase because the uppercase version was only printed, and wasn't store back.")

#substring s1 that does store the uppder case value
s1 = word1.upper()

#word1 was stored into s1, after being upper cased but it's self didn't get reassigned so it is still lower case
print('s1 is', s1, '\nword1 is', word1)
print('word1 didn\'t change because s1 is a substring of word1 and was assigned \'word1.uper()\', but this still doesn\'t change word1\'s value')

#---------Part 2---------

#word2 input from user
word2 = input('Input word two ')
#.capitalize() capatalizes the first letter of the word, and in this form doesn't store it back into word2
print('word2 is now', word2.capitalize())

#s2 is the capatalized word2, but didn't store it into word2 leaving it in it's original form
s2 = word2.capitalize()
print('s2 is', s2, '\nword2 is', word2)
print('word2 didn\'t change despite s2 being assigned it\'s value, becuase it wasn\'t stored into word2. s2 is also a substring, which is stand alone from word2\'s value')

#---------Part 3---------

word3 = input('Input word three with at least 2 uppercase and 2 lowercase:')
#swapcase() is used to swap all capitalized and lower case letters
print(word3.swapcase(), '\n{}'.format(word3))

#---------Part 4---------

word4 = input('Input word four:')
#len() is used to get the length of a string put inside of the ()
print(word4, ' has a length of', len(word4))

#to print a single character of a string use [x]. The last letter is the length of the word minus 1
print('The first character of', word4, 'is', word4[0])
print('The last character of', word4, 'is', word4[len(word4) - 1])
print()

#---------Part 5---------

#Three words were concatinated but two were variables and the last was a string
word5 = 'Western '
word6 = 'University '
phrase1 = word5 + word6 + 'Oregon'
print(phrase1, end=' ')

#---------Part 6---------

#In this section, a list of friends was made and then had a friend changed, added, removed, and the length taken
friends = ['Anette', 'Shannon', 'Kim', 'Melissa', 'Roslyn']
print(friends)
print('\nThe last person in my list is', friends[len(friends) - 1])
friends[0] = 'Fred Flintstone'
print(friends)
friends += ['Barney Rubble']
print(friends)
friends.remove('Fred Flintstone')
print(friends)
print('The length of my list is', len(friends))