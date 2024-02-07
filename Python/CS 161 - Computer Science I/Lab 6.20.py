# -*- coding: utf-8 -*-
"""

CS 161
Lab 6.19
Justin Davis
Partner : Rylie
This is a temporary script file.
"""

# Type all other functions here

#Gets the number of non whitespace characters in the string.
def get_num_of_non_WS_characters(userStr):
    count = 0
    for i in userStr:
        #checking for white space to ignore and takes count of actual characters.
        if not i.isspace():
            count += 1
    return count


#Get the number of words from the string entered.
def get_num_of_words(userStr):
    count = 0
    i = 0
    while i < len(userStr):
        #catchs spaces, tabs, and periods to signify a new word.
        if userStr[i] == ' ' or userStr[i] == '\t' or userStr[i] == '.' or userStr[i] == '!':
            count += 1
            i += 1
            if i < len(userStr):
                while userStr[i] == ' ' or userStr[i] == '\t' or userStr[i] == '.' or userStr[i] == '!':
                    i += 1
                #if this check isn't here it over counts by going into the else when multiple spaces or '.' are in the string.
                if userStr[i] == ' ' or userStr[i] == '\t' or userStr[i] == '.':
                    count += 1
                    i += 1
        else:
            i += 1
    return count


#Capitalizes the first word of every sentence
def fix_capitalization(userStr):
    new_string = userStr[0].upper()
    count = 1
    i = 1
    while i < len(userStr):
        if userStr[i] == '.':
            new_string += userStr[i]
            i += 1
            #needs to check so it doesn't move on into the loops and increment past the string length. Continue breaks to the while.
            if i >= len(userStr):
                continue
            while userStr[i] == ' ' or userStr[i] == '.' or userStr[i] == '\t' or userStr[i] == '!':
                new_string += userStr[i]
                #needs to check so it doesn't move on into the loops and increment past the string length. Continue breaks to the while.
                if i >= len(userStr):
                    continue
                else:
                    i +=1
            new_string += userStr[i].upper()
            count += 1
            #needs to check so it doesn't move on into the loops and increment past the string length. Continue breaks to the while.
            if i >= len(userStr):
                continue
            else:
                i += 1
        else:
            new_string += userStr[i]
            #needs to check so it doesn't move on into the loops and increment past the string length. Continue breaks to the while.
            if i >= len(userStr):
                continue
            else:
                i +=1              
    print('Number of leters capitalized:', count)
    return new_string 


#Replaces '!' and ';' with '.' and ',' respectivly and keeps track of how many of each is done.
def replace_punctuation(userStr, ex_count = 0, sem_count = 0):
    new_string = ''
    for a in userStr:
        if a == '!':
            new_string += '.'
            ex_count += 1
        elif a == ';':
            new_string += ','
            sem_count += 1
        else:
            new_string += a
    print('exclamationCount:', ex_count)
    print('semicolonCount:', sem_count)
    return new_string

#Detects repeated spaces and replaces them with single spaces
def shorten_space(userStr):
    new_string = ''
    i = 0
    while i < len(userStr):
        if i > len(userStr):
            break
        else:
            if userStr[i] == ' ' and userStr[i+1] == ' ':
                new_string += ' '
                if i > len(userStr):
                        continue
                else:
                    i += 2
            else:
                if i > len(userStr):
                        continue
                else:
                    new_string += userStr[i]
                    i += 1
    return new_string

#Prints out the menu of options.
def print_menu(userStr):

   # Complete print_menu() function
   print('\nMENU')
   print('c - Number of non-whitespace characters')
   print('w - Number of words')
   print('f - Fix capitalization')
   print('r - Replace punctuation')
   print('s - Shorten spaces')
   print('q - Quit')
    

if __name__ == '__main__':
    # Complete main section of code   
    menuOp = ' '
    userStr = input('Enter a sample text:\n\n')
    print('You entered:', userStr)
    print_menu(userStr)
    while 'c' != menuOp != 'w' and 'w' != menuOp != 'f' and 'r' != menuOp != 's' and menuOp != 'q':
       menuOp = input('\nChoose an option:\n')
    while menuOp != 'q':      
       if menuOp == 'c':
           print('Number of non_whitespace characters: %d' % get_num_of_non_WS_characters(userStr))
           print_menu(userStr)
       elif menuOp == 'w':
           print('Number of words: %d' % get_num_of_words(userStr))
           print_menu(userStr)
       elif menuOp == 'f':
           print('Edited text: {}'.format(fix_capitalization(userStr)))
           print_menu(userStr)
       elif menuOp == 'r':
           print('Punctuation replaced\n{}'.format(replace_punctuation(userStr)))
           print_menu(userStr)
       elif menuOp == 's':
           print('Edited text:', shorten_space(userStr))
           print_menu(userStr)
       menuOp = input('\nChoose an option:\n')