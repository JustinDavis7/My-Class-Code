# -*- coding: utf-8 -*-
"""
CS 162

Justin Davis
Abraham Vela
Matt Atkins
"""
# 1. Rainy day case(s)
# 2. Approach to handle the rainy day case(s)

# Ask the user for two coordinates, divide them, and print them
def user_input_for_coordinates(): 
    for i in range(3): 
        while True:
            try:
                x = int(input('Enter in x cordinate: '))
                y = int(input('Enter in y cordinate: '))
                print(x, '/', y, '=', x/y)
                break
            except ValueError:
                print('Input should be an integer.')
            except ZeroDivisionError:
                print('Y coordinate cannot be zero.')
            except:
                print('Unknown error has occured.')

# Ask the user for their age, check if they are 18 and print a message
def user_input_for_legal_age():
    try:
        age = int(input('Enter in your age: '))
        if age < 0:
            raise 
        if age < 18:
            print('Legal age is 18 or over.')
        else:
            print('You are of legal age.')
    except:
        print('Age must be greater then 0 and a number.')

def main():
    user_input_for_coordinates()
    
    user_input_for_legal_age()
    
main()