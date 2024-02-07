
class Counter :
    _count = 0
    ## Get the current value of the counter
    # @return the current value of the counter
    def getCount(self) :
        return self._count
    
    def clickArrived(self) :
        self._count = self._count + 1
        
    def clickLeft(self) :
        self._count = self._count - 1
        
    def resetCoutn(self) :
        self._count = 0
        
    def setCount(self, count):
        self._count - count