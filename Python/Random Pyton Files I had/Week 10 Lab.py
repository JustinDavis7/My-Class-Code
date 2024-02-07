# -*- coding: utf-8 -*-
"""

CS 161
Week 10 Lab
Justin Davis

"""
def makeAMove(board,player):
    ok = False
    while ok == False:
        row = input('Enter the row of your move:')
        column = input('Enter the column of your move:')
        if board[row][column] != ' ' or 1 < row > 3 or 1 < column > 3:
            print('Invalid, chose another board location.')
            ok = False
        else:
            ok = True
        
def displayBoard(board):
    i = 0
    j = 0
    print('|', end='')
    while i < 3:
        while j < 3:
            print(board[i][j], '|', end='')
            j += 1
        i += 1
    j = 0
    while i < 6:
        while j < 3:
            print(board[i][j], '|', end='')
            j += 1
        i += 1
    j = 0
    while i < 9:
        while j < 3:
            print(board[i][j], '|', end='')
            j += 1
            i += 1
            
