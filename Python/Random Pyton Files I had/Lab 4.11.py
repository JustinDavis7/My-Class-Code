# -*- coding: utf-8 -*-
"""

Lab 4.11
CS 161
Justin Davis
Partner: T.J. 

This is a temporary script file.
""" 
auto_service = {
        'Oil change' : 35,
        'Tire rotation': 19,
        'Car wash': 7}

needed_service = input('Enter desired auto service:\n')
if 'Oil change' != needed_service and 'Tire rotation' != needed_service and 'Car wash' != needed_service:
    print('You entered: {}\nError: Requested service is not recognized'.format(needed_service))
else:
    print('You entered: {}\nCost of {}: ${}'.format(needed_service, needed_service.lower(), auto_service[needed_service]))   
