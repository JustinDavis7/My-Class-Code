"""
CS 162

Justin Davis
Partner: Jasper
"""
def print_num_pattern(num1, num2):
    # temp_num1 = num1
    # while temp_num1 >0:
    #     print(temp_num1, end=' ')
    #     temp_num1 -= num2
    # print(temp_num1, end=' ')
    # while temp_num1 < num1:
    #     temp_num1 += num2
    #     print(temp_num1, end=' ')
    if num1 <= 0:
        print(num1, end=' ')
        return
    print(num1, end=' ')
    print_num_pattern(num1-num2,num2)
    print(num1, end=' ')

if __name__ == "__main__":
    num1 = int(input())
    num2 = int(input())
    print_num_pattern(num1, num2)