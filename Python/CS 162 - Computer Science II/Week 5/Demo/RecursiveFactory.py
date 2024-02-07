houses = ['Sheldons House', 'Leonards House', 'Bernadettes House', 'Pennys House', 'Howards House', 'Rajeshs House']


def deliver_presents_recursive(houses):
    if len(houses) == 1:
        house = houses[0]
        print(f'Stopping at {house}')
    else:
        mid = len(houses) // 2
        first_half = houses[:mid]
        second_half = houses[mid:]

        deliver_presents_recursive(first_half)
        deliver_presents_recursive(second_half)

def deliver_presents_iterative(houses):
    for house in houses:
        print(f'Stopping at {house}')


# deliver_presents_recursive(houses)
deliver_presents_iterative(houses)
