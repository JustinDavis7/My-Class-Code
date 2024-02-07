# -*- coding: utf-8 -*-
"""
Created on Wed Feb  5 13:00:40 2020

@author: Justin
"""
import turtle

wn = turtle.Screen()
wn.bgcolor("White")
wn.title("Turtle")
turt = turtle.Turtle()

turt.color('Orange')
turt.forward(30)
turt.right(70)
turt.forward(40)
turt.left(60)
turt.forward(90)
turt.right(130)
turt.forward(200)
turt.right(136)
turt.forward(185)
turt.color('Red')
turt.write("What even is that shape?")

turt.penup()
turt.forward(100)
turt.pendown()
turt.color('Green')
turt.forward(100)
turt.right(90)
turt.forward(100)
turt.right(90)
turt.forward(100)
turt.right(90)
turt.forward(100)
turt.right(90)
turt.penup()
turt.forward(100)
turt.color('Dark Blue')
turt.write('Well that\'s a normal shape at least...')

turt.left(130)
turt.forward(200)
turt.pendown()
turt.color('Magenta')
turt.forward(90)
turt.left(120)
turt.forward(90)
turt.left(120)
turt.forward(90)
turt.penup()
turt.left(90)
turt.forward(60)
turt.color('Black')
turt.write('That\'s a crooked triangle, but at least it\'s normal')