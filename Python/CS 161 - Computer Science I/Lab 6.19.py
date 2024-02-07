# -*- coding: utf-8 -*-
"""

CS 161
Lab 6.19
Justin Davis
Partner : Rylie
This is a temporary script file.
"""
def get_num_of_characters(inputStr):
    # Type your code here
    length = len(inputStr)
    return length

def output_without_whitespace(inputStr):
    string = ''
    i = 0
    while i < len(inputStr):
        if '\t' != inputStr[i] != ' ':
            string += inputStr[i]
        i += 1
    return string         

if __name__ == '__main__':
    # Type your code here
    inputStr = input('Enter a sentence or phrase:\n\n')
    print('You entered: {}'.format(inputStr))
    length = get_num_of_characters(inputStr)
    print('\nNumber of characters:', length)
    print('String with no whitespace:', output_without_whitespace(inputStr))