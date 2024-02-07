# -*- coding: utf-8 -*-
"""

Lab 4.12
CS 161
Justin Davis
Partner : T.J.

This is a temporary script file.
""" 
auto_service = {
        'Oil change' : 35,
        'Tire rotation': 19,
        'Car wash': 7,
        'Car wax': 12}
print('Davy\'s auto shop services\nOil change -- $35\nTire rotation -- $19\nCar wash -- $7\nCar wax -- $12')
first_service = input('\nSelect first service:\n')
second_service = input('Select second service:\n')
print('\nDavy\'s auto shop invoice\n')

if first_service == '-':  
    print('Service 1: No service')
    print('Service 2: {}, ${}\n'.format(second_service, auto_service[second_service]))
    print('Total: ${}'.format(auto_service[second_service]))    
elif second_service == '-':   
    print('Service 1: {}, ${}'.format(first_service, auto_service[first_service]))
    print('Service 2: No service\n')
    print('Total: ${}'.format(auto_service[first_service]))
else:
    print('Service 1: {}, ${}'.format(first_service, auto_service[first_service]))
    print('Service 2: {}, ${}\n'.format(second_service, auto_service[second_service]))
    print('Total: ${}'.format((auto_service[first_service] + auto_service[second_service])))