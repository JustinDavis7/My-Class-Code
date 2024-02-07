# reverse a string
# 'cab' -> 'bac'
def reverse(s):
    #this is much less demanding of the stack then the recursive
    result = ''
    for c in s:
        result = c + result
    return result

def reverse_rec(s):
    if len(s) == 0:
        return s
    else:
        return reverse_rec(s[1:]) + s[0]

#print(reverse_rec('graduation'))
x = 'graduation'
print(x[len(x)::-1]) #this is much cleaner