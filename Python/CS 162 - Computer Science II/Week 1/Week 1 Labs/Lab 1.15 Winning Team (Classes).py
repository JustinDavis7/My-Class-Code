# -*- coding: utf-8 -*-
"""
CS 162
Week 1 Lab 1.15 Winning Team (Classes)
Justin Davis
"""

class Team:
    def __init__(self):
        self.team_name = 'none'
        self.team_wins = 0
        self.team_losses = 0

    # TODO: Define get_win_percentage()
    def get_win_percentage(self):
        wins = self.team_wins
        losses = self.team_losses
        average = wins/(wins+losses)
        return average

if __name__ == "__main__":
    
    team = Team()
   
    team_name = input()
    team_wins = int(input())
    team_losses = int(input())
    
    team.team_name = team_name
    team.team_wins = team_wins
    team.team_losses = team_losses
    
    if team.get_win_percentage() >= 0.5:
        print('Congratulations, Team', team.team_name,'has a winning average!')
    else:
        print('Team', team.team_name, 'has a losing average.')