"""
CS 162

Justin Davis
Partner: Jasper
"""
def all_permutations(permList, nameList):
    # TODO: Implement method to create and output all permutations of the list of names.
    size = len(nameList)
    if size == 0:
        for i in range(len(permList)):
            print(permList[i], end=' ')
        print()
    else:
        for i in range(size):
            newperms = permList.copy()
            newperms.append(nameList[i])
            newnames = nameList.copy()
            newnames.pop(i)
            all_permutations(newperms, newnames)

if __name__ == "__main__":
    nameList = ['Julia', 'Lucas', 'Mia']
    permList = []
    all_permutations(permList, nameList)
