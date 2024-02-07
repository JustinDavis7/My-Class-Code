# -*- coding: utf-8 -*-
"""

CS 161
Lab 8.26
Justin Davis
Partner: Dylan
LAB*: Program: 
    Soccer team roster (Dictionaries)
"""

def get_key(val): 
    for key, value in player_list.items(): 
         if val == value: 
             return key

i = 1
player_list = {}


while i <= 5:
    player_number = int(input('Enter player {}\'s jersey number:\n'.format(i)))
    player_raiting = int(input('Enter player {}\'s rating:\n\n'.format(i)))
    player_list[player_number] = player_raiting
    i += 1

jersey_numbers = sorted(list(player_list.keys()))

print('ROSTER')
for j in jersey_numbers:
    print('Jersey number: {}, Rating: {}'.format(j, player_list[j]))

print('MENU')
print('a - Add player\nd - Remove player\nu - Update player rating\nr - Output players above a rating\no - Output roster\nq - Quit')

user_choice = input('Choose an option:')

while user_choice != 'q':
    if user_choice == 'a':
        player_number = int(input('Enter player {}\'s jersey number:\n'.format(i)))
        player_raiting = int(input('Enter player {}\'s rating:\n\n'.format(i)))
        player_list[player_number] = player_raiting
        i += 1
    elif user_choice == 'd':
        number = int(input('Enter a jersey number:'))
        player_list.pop(number)
    elif user_choice == 'r':
        rating = int(input('Enter a rating:'))
        print('\nABOVE', rating)
        rating_numbers = sorted(list(player_list.values()))
        for j in rating_numbers:
            if j >= rating:
                print('Jersey number: {}, Rating: {}'.format(get_key(j), j))
    elif user_choice == 'u':
        number = int(input('Enter a jersey number:'))
        rating = int(input('Enter a new rating for player:'))
        player_list.pop(number)
        player_list[number] = rating
    elif user_choice == 'o':
        jersey_numbers = sorted(list(player_list.keys()))
        print('ROSTER')
        for j in jersey_numbers:
            print('Jersey number: {}, Rating: {}'.format(j, player_list[j]))
    elif user_choice == 'q':
        break
    user_choice = input('Choose an option:')