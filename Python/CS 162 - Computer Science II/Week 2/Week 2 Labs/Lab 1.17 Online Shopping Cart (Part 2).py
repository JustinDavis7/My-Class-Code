# -*- coding: utf-8 -*-
"""
CS 162
Lab 1.17 Online Shopping Cart (Part 2)

Justin Davis
"""
class ItemToPurchase:
#    Class structor for the given item that will be purchased
    def __init__(self, item_name = 'none', item_price = 0.0, item_quantity = 0, item_description = 'none'):
#        Default constructor to set all of the variables of the ItemToPurchase either from standard values or passed in values
        self.item_name = item_name
        self.item_price = item_price
        self.item_quantity = item_quantity
        self.total_cost = item_price*item_quantity
        self.item_description = item_description
        
    def print_item_cost(self):
#        Prints out the cost of an item
        print('{} {} @ ${} = ${}'.format(self.item_name,self.item_quantity, self.item_price, (self.total_cost)))
        
    def print_item_description(self):
#        Prints out the description of an item
        print('{}: {}'.format(self.item_name, self.item_description))
 
class ShoppingCart:
#    Class structor to contain all of the ItemToPurchase objects
    def __init__(self, customer_name = 'none', current_date = 'January 1, 2016', cart_items = []):
#        Default constructor to set all of the variables of the ShoppingCart either from standard values or passed in values
        self.customer_name = customer_name
        self.current_date = current_date
        self.cart_items = cart_items
        
    def add_item(self, item = ItemToPurchase()):
#        Allows a user to add a new item into the cart based on user input
        if item.item_name == 'none':
            name = input('Enter the item name:\n') 
            description = input('Enter the item description:\n')
            price = int(input('Enter the item price:\n'))
            quantity = int(input('Enter the item quantity:\n'))     
            item = ItemToPurchase(name, price, quantity, description)
        
        self.cart_items.append(item)
        
    def remove_item(self, item_name):
#        Allows a user to remove a given item, based on the name provided
        found = False
        for item in self.cart_items:
            if item.item_name == item_name:
                found = True
                self.cart_items.remove(item)
                break
        if found == False:
            print('Item not found in cart. Nothing removed.')
        
    def modify_item(self, item = ItemToPurchase()):
#        Allows a user to modify the description of an item
        found = False
        for i in range(len(self.cart_items)):
            if self.cart_items[i].item_name == item.item_name:
                found = True
                self.cart_items[i].item_quantity = item.item_quantity
                self.cart_items[i].total_cost = self.cart_items[i].item_price * self.cart_items[i].item_quantity
                break
        if found == False:
            print('Item not found in cart. Nothing modified.')
            
        
    def get_num_items_in_cart(self):
#        Simply calculates the number of items in the cart by the len of the list
        number_of_items = 0
        for item in self.cart_items:
            number_of_items += item.item_quantity
        return number_of_items
        
    def get_cost_of_cart(self):
#        Calculates all of the items total costs that currently are part of the ShoppingCart
        cost = 0
        for item in self.cart_items:
            cost += (item.item_price * item.item_quantity)
        return cost
        
    def print_total(self):
#        Prints the total value or cost of all items in the ShoppingCart
        if len(self.cart_items) == 0:
            print('{}\'s Shopping Cart - {}\nNumber of Items: {}\n'.format(self.customer_name, self.current_date, self.get_num_items_in_cart()))
            print('SHOPPING CART IS EMPTY\n\nTotal: $0')
        else:
            print('{}\'s Shopping Cart - {}\nNumber of Items: {}\n'.format(self.customer_name, self.current_date, self.get_num_items_in_cart()))
            i = 0
            j = len(self.cart_items)
            while i < j:
                print(self.cart_items[i].print_item_cost())
                i +=1
            print('Total: ${}'.format(self.get_cost_of_cart()))
        
    def print_descriptions(self):
#        Prints the descriptions of all items in the ShoppingCart
        print('{}\'s Shopping Cart - {}\n\nItem Descriptions'.format(self.customer_name, self.current_date))
        for item in self.cart_items:
            item.print_item_description()

def print_menu(cart = ShoppingCart()):
    option = 'f'
    while option != 'q':    
        print('\nMENU\na - Add item to cart\nr - Remove item from cart\nc - Change item quantity\ni - Output items\' descriptions\no - Output shopping cart\nq - Quit\n')
        option = input('Choose an option:\n')
        while option != 'a' and option != 'r' and option != 'c' and option != 'i' and option != 'o' and option != 'q':
            option = input('Choose an option:\n')
        if option == 'a':
            print('\nADD ITEM TO CART')
            cart.add_item()
        elif option == 'r':
            item = input('\nREMOVE ITEM FROM CART\nEnter name of item to remove:\n')
            cart.remove_item(item)
        elif option == 'c':
            item_to_modify = ItemToPurchase() 
            item_to_modify.item_name = input('CHANGE ITEM QUANTITY\nEnter the item name:\n')
            item_to_modify.item_quantity = int(input('Enter the new quantity:\n'))
            cart.modify_item(item_to_modify)
        elif option == 'i':
            print('\nOUTPUT ITEMS\' DESCRIPTIONS')
            cart.print_descriptions()
        elif option == 'o':
            print('OUTPUT SHOPPING CART')
            cart.print_total()
    
if __name__ == "__main__":
    name = input('Enter customer\'s name:\n')
    date = input('Enter today\'s date:\n')
    print('\nCustomer name: {}\nToday\'s date: {}'.format(name, date))
    cart = ShoppingCart(name, date)
    print_menu(cart)
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    