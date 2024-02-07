# -*- coding: utf-8 -*-
"""
CS 161

Justin Davis
"""
def makeAMove(board,player):
	row = int(input('Enter a row for player {}:'.format(player)))
        column = int(input('Enter a column for player {}:'.format(player)))
	board_spot = row + column
	if board[board_spot] == ' '
		board[board_spot] = player

