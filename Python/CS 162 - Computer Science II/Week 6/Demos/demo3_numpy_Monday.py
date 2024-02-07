import numpy as np

# 1 dimensional array
my_array1 = np.array([15.5, 25.11, 19.0])
print(f'my_array1: {my_array1}\n')

# dimension array
my_array2 = np.array([(34, 25),(16,12)])
print(f'my_array2: {my_array2}\n')

# zero array
zero_array = np.zeros((1, 5))
print(f'zero_array: {zero_array}\n')

# 5 dimension array with 2 elements in each dimension
one_array = np.ones((5,2))
print(f'one_array: {one_array}\n')

# adding arrays
array1 = np.array([10,20,30,40])
array2 = np.array([1,2,3,4])

print(f'Adding array1 + array2 = {array1 + array2}')

print(f'Square root of array1 elements: {np.sqrt(array1)}')

print(f'The max of array1 is {array1.max()}')