# -*- coding: utf-8 -*-
"""
CS 161

Justin Davis
"""

def increase_dupe(nums):
    """
    Finds the last duplicated value as well as the largest increase between 2 consecutive index from a list.
    
    Parameters:
        nums (list): A list of ints
    
    Returns:
        distance: The maximum increase from two consecutive index.
        dupe: The last value that shows up back-to-back with the same value.
        
    """
    distance = 0
    dupe = 0
    for index, item in enumerate(nums):
        if index >= len(nums)-1:
            break
        else:
            distance2 = nums[index+1] - nums[index]
            if distance2 > distance:
                distance = distance2
        if nums[index] == nums[index+1]:
            dupe = nums[index]
    return distance, dupe 


def remove_non_int(string1):
    """
    Removes the comma's and blank spaces from a string to be reassigned as a list of ints
    
    Parameters:
        string1 (string): The user input string of numbers seperated by a comma and a space respectively.
        
    Returns:
        tokens2: A converted list of ints.
        
    """
    tokens1 = string1.split(',')
    tokens2 = []
    
    for i in tokens1:
        #removes the remaining spaces from the list after commas are removed.
        tokens2 += i.split()
     
    for i in tokens2:
        #casts the values in tokens2 to int for later use.
        tokens2[tokens2.index(i)] = int(tokens2[tokens2.index(i)])
    
    return tokens2
      
string1 = input('Enter numbers:')
nums1 = remove_non_int(string1)
    
increase, dupe = increase_dupe(nums1)
print('Greatest increase:', increase, '\nLast duplicate:', dupe)
