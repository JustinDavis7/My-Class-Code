# -*- coding: utf-8 -*-
"""
CS 162
Week 1 Lab 1.13 Artwork Label (Classes-Constructors)
Justin Davis
"""
class Artist:
    # TODO: Define constructor with parameters to initialize instance attributes
    #       (name, birth_year, death_year)
    def __init__(self, name='None', birth_year = 0, death_year= 0):
        self.name = name
        self.birth_year = birth_year
        self.death_year = death_year
    # TODO: Define print_info() method. If death_year is -1, only print birth_year
    def print_info(self):
        if self.death_year != -1:
            print('Artist: {} ({}-{})'.format(self.name,self.birth_year,self.death_year))
        else:
            print('Artist: {}, born {}'.format(self.name,self.birth_year))
      
class Artwork:
    # TODO: Define constructor with parameters to initialize instance attributes
    #       (title, year_created, artist)
    def __init__(self, title='None', year_created = 0, artist = Artist()):
        self.title = title
        self.year_created = year_created
        self.artist = artist
    # TODO: Define print_info() method
    def print_info(self):
        self.artist.print_info()
        print('Title: {}, {}'.format(self.title, self.year_created,))

if __name__ == "__main__":
    user_artist_name = input()
    user_birth_year = int(input())
    user_death_year = int(input())
    user_title = input()
    user_year_created = int(input())

    user_artist = Artist(user_artist_name, user_birth_year, user_death_year)

    new_artwork = Artwork(user_title, user_year_created, user_artist)
  
    new_artwork.print_info()
