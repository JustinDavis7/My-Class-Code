"""
CS 162
Searching Lab - Video game search engine

Justin Davis
Partner: Moshe, Marcos
"""
import csv
from stopwatch import Stopwatch


class VideoGameSearchEngine():
    def __init__(self, csv_filename):
        with open(csv_filename, 'r') as csvfile:
            game_file = csv.reader(csvfile, delimiter=',')
            data = []
            for row in game_file:
                data.append(row)
        self._data = data

    def linear_search_filer(self, search_terms, column_index):
        watch = Stopwatch()
        two_d_list = []
        for term in search_terms:
            for i in range(len(self._data)):
                if term in self._data[i][column_index]:
                    two_d_list.append(self._data[i])
        return two_d_list, watch.elapsed()

    def print_results(results, search_time):
        print('Search results:\n{:<12}{:<27}{:<11}{:<12}{:<12}{:<16}{:<16}{:<6}'.format('ID Number','Name','Platform', 'Year', 'Genre', 'Publisher', 'Developer', 'Rating\n'))
        for i in results:
            print('{:<12}{:<27}{:<11}{:<12}{:<12}{:<16}{:<16}{:<6}'.format(i[0][:12],i[1][:25],i[2][:10],i[3][:11],i[4][:11],i[5][:15],i[6][0:15],i[7][:5]))
        print(f'\nTotal search time: {search_time}. Total results: {len(results)}')


# a = VideoGameSearchEngine('video_game_data.csv')
# list, timer = a.linear_search_filer(['2000'], 3)
#
# VideoGameSearchEngine.print_results(list, timer)

def main():
    engine = VideoGameSearchEngine('video_game_data.csv')
    user_continue = True
    search = ''
    while user_continue:
        user_choice = int(input('VIDEO GAME SEARCH ENGINE\nChoose search option:\n(0) Id Number\n(1) Name\n(2) Platform\n(3) Year\n(4) Genere\n(5) Publisher\n(6) Developer\n(7) Rating\n--> '))
        if user_choice == 0:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search,0)
        elif user_choice == 1:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 1)
        elif user_choice == 2:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 2)
        elif user_choice == 3:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 3)
        elif user_choice == 4:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 4)
        elif user_choice == 5:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 5)
        elif user_choice == 6:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 6)
        else:
            search = input('Enter search term(s):')
            temp = search.split(' ')
            search = temp
            result_list, timer = engine.linear_search_filer(search, 7)

        VideoGameSearchEngine.print_results(result_list, timer)
        user_choice = input('Search again? (Y)es or (N)o:')
        if user_choice == 'Y' or user_choice == 'y':
            user_continue = True
        else:
            user_continue = False
main()