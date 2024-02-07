import csv

class NetworkAnalyzer:
    def __init__(self, filename):
        self._data = []
        self._read_csv(filename)

    def _read_csv(self, filename):
        with open(filename) as file:
            next(file)
            for line in csv.reader(file, delimiter=',', skipinitialspace=True):
                self._data.append(tuple(line))

    def ips_by_connection(self):
        ips_by_connection_dict = dict()

        for item in self._data:
            source_ip = item[2]
            ips_by_connection_dict[source_ip] = ips_by_connection_dict.get(source_ip, 0) + 1

        ips_by_connection_list = list(ips_by_connection_dict.items())

        ips_by_connection_sorted = self.quicksort(ips_by_connection_list, 0, len(ips_by_connection_list) - 1, 1)

        return ips_by_connection_sorted

    def ips_by_bytes(self):
        ips_by_bytes_dict = dict()

        for item in self._data:
            source_ip = item[2]
            ips_by_bytes_dict[source_ip] = ips_by_bytes_dict.get(source_ip, 0) + int(item[5])

        ips_by_bytes_list = list(ips_by_bytes_dict.items())

        ips_by_bytes_sorted = self.quicksort(ips_by_bytes_list, 0, len(ips_by_bytes_list)-1, 1)

        return ips_by_bytes_sorted

    def protocols_by_connections(self):
        protocols_by_connections_dict = dict()

        for item in self._data:
            source_protocol = item[4]
            protocols_by_connections_dict[source_protocol] = protocols_by_connections_dict.get(source_protocol, 0) + 1

        protocols_by_connections_list = list(protocols_by_connections_dict.items())

        protocols_by_connections_sorted = self.quicksort(protocols_by_connections_list, 0, len(protocols_by_connections_list)-1, 1)

        return protocols_by_connections_sorted

    def protocols_by_bytes(self):
        protocols_by_bytes_dict = dict()

        for item in self._data:
            source_protocol = item[4]
            protocols_by_bytes_dict[source_protocol] = protocols_by_bytes_dict.get(source_protocol, 0) + int(item[5])

        protocols_by_bytes_list = list(protocols_by_bytes_dict.items())

        protocols_by_bytes_sorted = self.quicksort(protocols_by_bytes_list, 0, len(protocols_by_bytes_list)-1, 1)

        return protocols_by_bytes_sorted

    def connections_by_connections(self):
        connections_by_connections_dict = dict()

        for item in self._data:
            source_ip = item[2:4]
            connections_by_connections_dict[source_ip] = connections_by_connections_dict.get(source_ip, 0) + 1

        connections_by_connections_list = list(connections_by_connections_dict.items())

        connections_by_connections_sorted = self.quicksort(connections_by_connections_list, 0, len(connections_by_connections_list) - 1, 1)

        return connections_by_connections_sorted

    def connections_by_bytes(self):
        connections_by_connections_dict = dict()

        for item in self._data:
            source_ip = item[2:4]
            connections_by_connections_dict[source_ip] = connections_by_connections_dict.get(source_ip, 0) + int(item[5])

        connections_by_connections_list = list(connections_by_connections_dict.items())

        connections_by_connections_sorted = self.quicksort(connections_by_connections_list, 0, len(connections_by_connections_list) - 1, 1)

        return connections_by_connections_sorted

    def quicksort(self, numbers, start_index, end_index, sort_index):
        # Only attempt to sort the list segment if there are
        # at least 2 elements
        if end_index <= start_index:
            return

        # Partition the list segment
        high = self.partition(numbers, start_index, end_index, sort_index)

        # Recursively sort the left segment
        self.quicksort(numbers, start_index, high, sort_index)

        # Recursively sort the right segment
        self.quicksort(numbers, high + 1, end_index, sort_index)

        return numbers

    def partition(self, numbers, start_index, end_index, sort_index):
        # Select the middle value as the pivot.
        midpoint = start_index + (end_index - start_index) // 2
        pivot = numbers[midpoint][sort_index]

        # "low" and "high" start at the ends of the list segment
        # and move towards each other.
        low = start_index
        high = end_index

        done = False
        while not done:
            # Increment low while numbers[low] < pivot
            while numbers[low][sort_index] < pivot:
                low = low + 1

            # Decrement high while pivot < numbers[high]
            while pivot < numbers[high][sort_index]:
                high = high - 1

            # If low and high have crossed each other, the loop
            # is done. If not, the elements are swapped, low is
            # incremented and high is decremented.
            if low >= high:
                done = True
            else:
                temp = numbers[low]
                numbers[low] = numbers[high]
                numbers[high] = temp
                low = low + 1
                high = high - 1

        # "high" is the last index in the left segment.
        return high



