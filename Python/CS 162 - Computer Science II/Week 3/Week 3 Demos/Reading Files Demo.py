# -*- coding: utf-8 -*-
"""
CS 162

Justin Davis
"""
#LEGACY
countries_legacy = open('sample.txt')

#lines = countries_legacy.readlines()
## This reads all lines
#line = countries_legacy.readline()

#while True:
## Can make a lot of bugs so not a good idea to do while True: loops
#    print(line)
#    line = countries_legacy.readline()
#    if not line:
#        break
    
#while line:
#    print(line)
#    line = countries_legacy.readline()
#countries_legacy.close()


#New way of doing files    
with open('sample.txt') as reader:
#    print(reader.read())
##    single read of entire file just like readlines()
    line = reader.readline()
    while line:
        print(line)
        line = reader.readline()