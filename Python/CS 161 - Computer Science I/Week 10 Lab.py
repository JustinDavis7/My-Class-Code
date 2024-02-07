# -*- coding: utf-8 -*-
"""

CS 161
Tic Tac Toe
Justin Davis

Make a Tic-Tac-Toe game with functions to do the various actions.
"""
def makeAMove(board,player):
    '''Allows the set player to place their mark in a given spot if it is open.'''
    
    valid = False
    while not valid:
        row = int(input('Enter a row for player {}:'.format(player)))
        column = int(input('Enter a column for player {}:'.format(player)))
        if board[row-1][column-1] == ' ':
            board[row-1][column-1] = player
            valid = True
        else:
            print('This cell is already occupied. Try a different cell.')
        
def displayBoard(board):
    '''Displays the whole board.'''
    
    print('-------------')
    for i in range(3):
        print('|', board[0][i], end=' ' )
    print('|')
    for i in range(3):
        print('|', board[1][i], end=' ' )
    print('|')
    for i in range(3):
        print('|', board[2][i], end=' ' )
    print('|\n-------------')
            
def isWon(ch, board):
    '''Checks each row, column, and diagonal for a winner.'''
    
    #Checking row 1 
    if board[0][0] == ch and board[0][1] == ch and board[0][2] == ch:
        return True
    #Checking row 2
    elif board[1][0] == ch and board[1][1] == ch and board[1][2] == ch:
        return True
    #Checking row 3
    elif board[2][0] == ch and board[2][1] == ch and board[2][2] == ch:
        return True
    #Moving to column checks-------------------------------------
    #Checking column 1
    elif board[0][0] == ch and board[1][0] == ch and board[2][0] == ch:
        return True
    #Checking column 2
    elif board[0][1] == ch and board[1][1] == ch and board[2][1] == ch:
        return True
    #Checking column 3
    elif board[0][2] == ch and board[1][2] == ch and board[2][2] == ch:
        return True
    #Moving to major diagonal-------------------------------------
    elif board[0][0] == ch and board[1][1] == ch and board[2][2] == ch: 
        return True
    #Moving to sub diagonal-------------------------------------
    elif board[0][2] == ch and board[1][1] == ch and board[2][0] == ch:
        return True          
    #Defalut return for a no win scenario
    return False

def isDraw(board):
    '''Checks if there are any valid spots to move and returns False if there is.'''
    
    for i in range(3):
        for j in range(3):
            if board[i][j] == ' ':
                return False
    return True

def playGame(board):
    '''The main body of the game itself. All of the functions are called 
    inside of this function, and it maintains the game state depending 
    on the results of each function.
    '''
    
    displayBoard(board)
    for i in range(5):       
        makeAMove(board,'X') 
        displayBoard(board)
        if i > 2:
            #No need to check for a win when there physically can't be one.
            if isWon('X',board):
                print('X player won')
                break
        
        makeAMove(board,'O')
        displayBoard(board)
        if i > 2:
            if isWon('O',board):
                print('O player won') 
                break
        
        if isDraw(board):
            print('The board is filled without a winner, it\'s a draw!')
        
 
board = [[' ', ' ', ' '], [' ', ' ', ' '], [' ', ' ', ' ']]
playGame(board)
