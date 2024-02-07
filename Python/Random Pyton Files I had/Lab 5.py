# -*- coding: utf-8 -*-
"""

Lab 5
CS 161
Justin Davis
Partner: Wyatt - Marcos

This is a temporary script file.
"""

p = int(input('Enter the loan amount:'))
n = int(input('Enter number of years as an integer:'))
r = float(input('Enter yearly interest rate:'))

n = n*12
r = (r/100)/12
a = p*((r*((1+r)**n))/(((1+r)**n)-1))

print('Monthly Payment:', '{:.2f}'.format(a))
print('Payment# \tPayment \tInterest \tPrincipal \tBalance')
      

balance = p
principal = a
total_payment=0

i = 0
while i < n:
    i += 1 
    interest = r * balance
    balance = balance - a  
    total_payment += a + interest  
    print('{:<15d} {:<15.2f} {:<15.2f} {:<15.2f} {:<15.2f}'.format(i, a, interest, principal-interest, balance))
    if balance < a:
        a = balance
        principal = balance
    
print('Total payments:', '{:.2f}'.format(total_payment))