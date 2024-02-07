# -*- coding: utf-8 -*-
"""
CS 162
Lab 1.16 Online Shopping Cart (Part 1)

Justin Davis
"""
# Type code for classes here
class ItemToPurchase:
    def __init__(self, item_name = 'none', item_price = 0.0, item_quantity = 0):
        self.item_name = item_name
        self.item_price = item_price
        self.item_quantity = item_quantity
        self.total_cost = item_price*item_quantity
        
    def print_item_cost(self):
        print('{} {} @ ${} = ${}'.format(self.item_name,self.item_quantity, self.item_price, (self.total_cost)))
        
if __name__ == "__main__":
    # Type main section of code here
    print('Item 1')
    name = input('Enter the item name:\n')
    #ZyBooks doesn't actually want this to be a float to pass tests, so I set it to an int to pass all 8 tests. 
    price = int(input('Enter the item price:\n'))
    quantity = int(input('Enter the item quantity:\n'))
    item1 = ItemToPurchase(name, price, quantity)
    
    print('\nItem 2')
    name = input('Enter the item name:\n')
    price = int(input('Enter the item price:\n'))
    quantity = int(input('Enter the item quantity:\n'))
    item2 = ItemToPurchase(name, price, quantity)
    
    print('\nTOTAL COST')
    item1.print_item_cost()
    item2.print_item_cost()
    print('\nTotal: ${}'.format(item1.total_cost + item2.total_cost))