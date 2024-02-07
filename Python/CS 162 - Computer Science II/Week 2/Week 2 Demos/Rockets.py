# -*- coding: utf-8 -*-
"""
CS 162

Justin Davis
"""
class Rocket():
    # Rocket simulates a rocket ship for a game, or a physics simulation
    
    def __init__(self, x = 0, y = 0):
        # Each rocket has an (x,y) position.
        self.x = x
        self.y = y
        
    def move_up(self):
        # Increment the y-position of the rocket.
        self.y += 1
        
    def __str__(self):
        # toString() method that gets called when the object call print on the object
        return 'x: {} y: {}'.format(self.x, self.y)

# Create a fleet of 5 rockets, and store them in a list.
my_rockets = [Rocket() for x in range(5)]

# Move the first rocket up.
my_rockets[0].move_up()

# Show that only the first rocket has moved.
for rocket in my_rockets:
    print('Rocket altitude:', rocket)