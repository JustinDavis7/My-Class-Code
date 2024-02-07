import matplotlib.pyplot as plt
import matplotlib.style as sty

plt.plot([1,2,3,4,5],[1,2,3,4,10], 'go', label='Green dots')
#plt.show

plt.plot([5,4,3,2,1],[2,3,4,5,11], 'b*', label='Blue stars')


plt.title('A simple scatter plot')

plt.xlabel('X')
plt.ylabel('y')

plt.xlim(0,6)
plt.ylim(0,12)

plt.legend(loc='best')

plt.show()

