# -*- coding: utf-8 -*-
"""

Week 6 In Class Part 2
CS 161
Justin Davis 

This is a temporary script file.
"""

def celsiusToFahrenheit(cel): # Converts Celsius to Fahrenheit
    fahr = (cel*1.8) + 32
    return fahr

def fahrenheitToCelsius(fahr): #Converts Fahrenheit to Celsius
    cel = (fahr - 32) * 5/9
    return cel

def main():
    print(format("Celsius", "<15s"), format("Fahrenheit", "<15s"), "  |    ", format("Fahrenheit", "<15s"), format("Celsius", "<15s")) 
    print("---------------------------------------------------------------")

    celsius = 40
    farenheit = 120
    i = 1
    
    while i <= 10:
        print(format(celsius, "<15d"), format(celsiusToFahrenheit(celsius), "<15.2f"), "  |    ", 
              format(farenheit, "<15d"), format(fahrenheitToCelsius(farenheit), "<15.2f"))
        celsius -= 1
        farenheit -= 10
        i += 1

main()