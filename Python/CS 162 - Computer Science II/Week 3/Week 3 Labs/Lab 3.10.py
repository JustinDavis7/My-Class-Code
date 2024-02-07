"""
CS 162
Lab 3.10

Justin Davis
"""
input_file = input()
user_file = open(str(input_file))
output_list = user_file.readlines()

my_dict = {}
show_list = []
show_list_split = []

for index in range(len(output_list)):
    temp_list = []
    list_object = output_list[index].strip('\n')
    if (index + 1 < len(output_list) and (index % 2 == 0)):
        if int(list_object) in my_dict:
            the_index = int(index)
            my_dict[int(list_object)].append(output_list[the_index + 1].strip('\n'))
        else:
            temp_list.append(output_list[index + 1].strip('\n'))
            my_dict[int(list_object)] = temp_list


my_dict_sorted_by_keys = dict(sorted(my_dict.items()))

for x in my_dict.keys():
    show_list.append(my_dict[x])
    
for x in show_list:
    for i in x:
        show_list_split.append(i)
        
f = open('output_keys.txt', 'w')
for key, value in my_dict_sorted_by_keys.items():
    f.write(str(key)+ ': ')
    for item in value[:-1]:
        f.write(item + '; ')
    f.write(value[-1])
    f.write('\n')
f.close()

f = open('output_titles.txt', 'w')
for i in sorted(show_list_split):
    f.write(i + '\n')
f.close()

