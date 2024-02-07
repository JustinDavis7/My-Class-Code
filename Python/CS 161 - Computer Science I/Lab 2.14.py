# -*- coding: utf-8 -*-
"""
Lab 2.14
CS 161
Justin Davis
Partner : Nick Mcclain

This is a temporary script file.
"""
itemName = input('Enter food item name:\n')

# FIXME (1): Finish reading item price and quantity, then output a receipt
itemPrice = float(input('Enter item price:\n'))
itemQuantity = int(input('Enter item quantity:\n'))

print('\nRECEIPT')
print(itemQuantity, itemName, '@ $', itemPrice, '= $', itemPrice*itemQuantity)
print('Total cost: $', itemPrice*itemQuantity)
# FIXME (2): Read in a second food item name, price, and quantity, then output a second receipt
itemName2 = input('\n\nEnter second food item name:\n')
itemPrice2 = float(input('Enter item price:\n'))
itemQuantity2 = int(input('Enter item quantity:\n\n'))

print('RECEIPT')
print(itemQuantity, itemName, '@ $', itemPrice, '= $', itemPrice*itemQuantity)
print(itemQuantity2, itemName2, '@ $', itemPrice2, '= $', itemPrice2*itemQuantity2)
print('Total cost: $', (itemPrice*itemQuantity) + itemPrice2*itemQuantity2)
  
# FIXME (3): Add a gratuity and total with tip to the second receipt
print()
print('15% gratuity: $', (((itemPrice*itemQuantity) + itemPrice2*itemQuantity2)) * 0.15)
print('Total with tip: $', ((itemPrice*itemQuantity) + itemPrice2*itemQuantity2) + ((((itemPrice*itemQuantity) + itemPrice2*itemQuantity2)) * 0.15))