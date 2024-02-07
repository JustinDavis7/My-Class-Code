"""
CS 162

Plotting Lab

Justin Davis
Partner: Abraham
"""
import matplotlib.pyplot as plt

high = []
low = []
months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

with open('data.txt', 'r') as file:
    for line in file:
        high_temp, low_temp = line.split(',')
        high.append(int(high_temp))
        low.append(int(low_temp))

plt.plot(months, high, color='Red', label='High')
plt.plot(months, low, color='Blue', label='Low')

plt.title('Salem Oregon City Temperatures: Averages by Month')
plt.xlabel('Months')
plt.ylabel('Temperature, in Fahrenheit degrees')
plt.legend(loc='upper left')

plt.show()
