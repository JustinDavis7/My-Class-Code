# -*- coding: utf-8 -*-
"""

Week 6 In Class Part 1
CS 161
Justin Davis 

This is a temporary script file.
"""

#Write a function that converts a decimal integer to hexadecimal.
import math
def main():
    #Prompt the user to enter a decimal integer
    decimalValue = eval(input('Enter a decimal number:'))
    
    print('Hex for decimal', decimalValue, 'is', decimalToHex(decimalValue))
    
def hex_char(hexi):
    if 10 > hexi >= 0:
        return hexi
    elif hexi == 10:
        return 'A'
    elif hexi == 11:
        return 'B'
    elif hexi == 12:
        return 'C'
    elif hexi == 13:
        return 'D'
    elif hexi == 14:
        return 'E'
    elif hexi == 15:
        return 'F'
        
def decimalToHex(decimal):
    if decimal < 10:
        number = decimal
    elif 26 > decimal/10 > 15:
        hexi = hex_char(decimal%16)
        decimal = hex_char(math.floor(decimal/16))
        number = str(decimal) + str(hexi)
    else:
        hexi = hex_char(decimal % 16)
        if (decimal/16) > 0:
            decimal = math.floor(decimal/16)
            number = str(decimal) + str(hexi)
        else:
            number = hexi
    return number
    
main()
    