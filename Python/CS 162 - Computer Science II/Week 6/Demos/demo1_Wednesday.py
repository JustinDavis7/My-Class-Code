import matplotlib.pyplot as plt

with open('dd_stats.csv', 'r') as file:
    total_fatalities = []
    alcohol_fatalities = []

    for line in file:
        total, alcohol = line.split(',')
        total_fatalities.append(int(total))
        alcohol_fatalities.append(int(alcohol))

years = range(1970, 2012)
plt.plot(years, total_fatalities, label='Total Fatalities')
plt.plot(years, alcohol_fatalities, label='Alcohol Fatalities')

plt.xlabel('Years')
plt.ylabel('Number of Alcohol Fatalities')
plt.title('Alcohol related fatalities on highway')
plt.legend(loc='upper right')

plt.text(1970, 11000, 'Fatalities spike\n in 1970', color='grey', fontsize=12)

plt.axvline(1980, color = 'red')

arrow_properties = {
    'facecolor': 'black',
    'shrink': 0.1,
    'headlength': 10,
    'width': 2
}

plt.annotate('Drinking age changed to 21',
             xy=(1984, 24762),
             xytext=(1986, 30000),
             arrowprops=arrow_properties)

plt.show()







