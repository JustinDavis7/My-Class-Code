import matplotlib.pyplot as plt

with open('ocean_temp.csv') as file:
    temps = []
    for t in file:
        temps.append(float(t))

years = range(1850, 2012)

#plt.plot(years, temps, 'go--', label='ocean temperatures')

pirate_years = range(1850, 2000, 25)
num_pirates_thousands = [20, 17, 15, 5, 0.4, 0.025]
plt.plot(pirate_years, num_pirates_thousands, 'b--', label='number of pirates')
plt.legend(loc='upper right', shadow=True)

plt.show()