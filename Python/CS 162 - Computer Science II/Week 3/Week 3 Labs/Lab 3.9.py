# -*- coding: utf-8 -*-
"""
CS 162
Lab 3.9

Justin Davis
"""
import csv
csv_input = input()
word_list = []
with open(csv_input, 'r') as csvfile:
    words = csv.reader(csvfile)
    for row in words:
        for i in range(len(row)):
            if row[i] not in word_list:
                print(row[i], row.count(row[i]))
                word_list.append(row[i])