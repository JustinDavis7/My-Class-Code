from network_analyzer import NetworkAnalyzer


def main():
    print('NETWORK ANALYZER\n')
    filename = input('Enter in the PCAP filename:')
    network_analyzer = NetworkAnalyzer(filename)
    user_choice = 0
    while user_choice != 6:
        user_choice = int(input('Choose analysis option:\n(0) IPs by Connection\n(1) IPs by Bytes\n(2) Protocols by Connections\n(3) Protocols by Bytes \n(4) Connections by Connections\n(5) Connections by Bytes\n(6) Quit\n -->'))
        if user_choice == 0:
            result = network_analyzer.ips_by_connection()
        elif user_choice == 1:
            result = network_analyzer.ips_by_bytes()
        elif user_choice == 2:
            result = network_analyzer.protocols_by_connections()
        elif user_choice == 3:
            result = network_analyzer.protocols_by_bytes()
        elif user_choice == 4:
            result = network_analyzer.connections_by_connections()
        elif user_choice == 5:
            result = network_analyzer.connections_by_bytes()
        elif user_choice == 6:
            break

        for i, item in enumerate(result):
            print(i, item)
        print()

if __name__ == '__main__':
    main()