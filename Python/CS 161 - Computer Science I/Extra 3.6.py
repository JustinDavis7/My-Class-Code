# -*- coding: utf-8 -*-
"""
Lab .
CS 161
Justin Davis
Partner : 

This is a temporary script file.
"""
exam1_grade = float(input('Enter score on Exam 1 (out of 100):\n'))
exam2_grade = float(input('Enter score on Exam 2 (out of 100):\n'))
exam3_grade = float(input('Enter score on Exam 3 (out of 100):\n'))

overall_grade = (exam1_grade + exam2_grade + exam3_grade) / 3

print('Your overall grade is:', overall_grade)

assignment1_grade = float(input('Enter score on Assignment 1 (out of 50):\n'))
assignment2_grade = float(input('Enter score on Assignment 2 (out of 50):\n'))
assignment3_grade = float(input('Enter score on Assignment 3 (out of 50):\n'))
assignment4_grade = float(input('Enter score on Assignment 4 (out of 50):\n'))

overall_assignment_grade = (((assignment1_grade/50) + (assignment2_grade/50) + (assignment3_grade/50) + (assignment4_grade/50)) / 4) * 100

print('Your overall grade is:', overall_assignment_grade)

assignment1_grade = float(input('Enter score on Assignment 1 (out of 50):\n'))
assignment2_grade = float(input('Enter score on Assignment 2 (out of 50):\n'))
assignment3_grade = float(input('Enter score on Assignment 3 (out of 75):\n'))
assignment4_grade = float(input('Enter score on Assignment 4 (out of 75):\n'))

overall_assignment_grade = (((assignment1_grade/50) + (assignment2_grade/50) + (assignment3_grade/75) + (assignment4_grade/75)) / 4) * 100

print('Your overall grade is:', overall_assignment_grade)

exam1_grade = float(input('Enter score on Exam 1 (out of 100):\n'))
exam2_grade = float(input('Enter score on Exam 2 (out of 100):\n'))
exam3_grade = float(input('Enter score on Exam 3 (out of 100):\n'))

avg_exam_score = (exam1_grade + exam2_grade + exam3_grade) / 3

assignment1_grade = float(input('Enter score on Assignment 1 (out of 50):\n'))
assignment2_grade = float(input('Enter score on Assignment 2 (out of 50):\n'))
assignment3_grade = float(input('Enter score on Assignment 3 (out of 50):\n'))
assignment4_grade = float(input('Enter score on Assignment 4 (out of 50):\n'))

avg_assignment_score = (assignment1_grade + assignment2_grade + assignment3_grade + assignment4_grade) / 4

print('Total Grade is:', (avg_exam_score*0.6) + (avg_assignment_score*0.4))