from Counter import Counter

# open store
counter1 = Counter()
counter2 = Counter()

# somebody arrived
counter1.clickArrived()

# somebody arrived
counter1.clickArrived()

# somebody arrived
counter1.clickArrived()

# somebody left
counter1.clickLeft()

# How many people in the store are left?
currentCount1 = counter1.getCount()
currentCount2 = counter2.getCount()

print("The current count in the store is (counter1): ", currentCount1)
print("The current count in the store is (counter2): ", currentCount2)