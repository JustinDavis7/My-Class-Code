# -*- coding: utf-8 -*-
"""
CS 162
Week 1 Lab 1.14 Triangle Area Comparison (Classes)
Justin Davis
"""

class Triangle:   
    def __init__(self):
        self.base = 0
        self.height = 0

    def set_base(self, user_base):
        self.base = user_base

    def set_height(self, user_height):
        self.height = user_height
   
    def get_area(self):
        area = 0.5 * self.base * self.height
        return area
   
    def print_info(self):
        print('Base: {:.2f}'.format(self.base))
        print('Height: {:.2f}'.format(self.height))
        print('Area: {:.2f}'.format(self.get_area()))

if __name__ == "__main__":
    triangle1 = Triangle()
    triangle2 = Triangle()

    # TODO: Read and set base and height for triangle1 (use set_base() and set_height())
    triangle1.set_base(float(input()))
    triangle1.set_height(float(input()))
    
    # TODO: Read and set base and height for triangle2 (use set_base() and set_height())
    triangle2.set_base(float(input()))
    triangle2.set_height(float(input()))
    
    # TODO: Determine larger triangle (use get_area())
      
    print('Triangle with larger area:')
    
    # TODO: Output larger triangle's info (use print_info())
    if triangle1.get_area() > triangle2.get_area():
        triangle1.print_info()
    else:
        triangle2.print_info()
