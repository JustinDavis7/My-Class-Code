# Final Part 2: Implementation
(Replace header above with Assignment # and Name; e.g. Assignment 01 Huffman Encoder)

## Term & Course Information
Spring 2021, CS 367 Software Design & Testing 202031442

## Developer Information
Justin Davis
JustinDavisWOU

## App Details

### Description
This is a Todo list. A user is going to be able to specify an existing todo.txt list or create a new one if one doesn't already exist.
The user is able to add items to the list, and the list will be compatable with any other device that makes use of the todo.txt format.
The program can also display all of the items still on the todo list that are incompleted, and will print them in order of priority.
The list output will also have the option to organize it depending on one of the other catagories of stored data (priority, project,
context, ect.). In addition to doing these actions for an incomplete list of items, the user can also display a list of their completed
tasks as well which is ordered decending by the completion date. Any of the elements of an item still in the incompleted list can be 
edited by the user. Once an item is marked as complete, the system will automatically move it to the completed list for storage.

### Release Notes

#### Limitations Based on Requirements and Rubric
The program allows a user to do all of the required tasks. The user can enter a file name, and the system will auto created both the todo, and the completed lists. From there, a user can enter a new task; view all of their todo tasks ordered by priority; view their todo tasks with a user defiened filter ranging from priority sort, project tag sorting, or context tag sorting; view their completed tasks which are ordered decending by completion date; and update a task. When a task is updated with a completion marker (x), the system notices and removes it from the todo and puts it into the completed list. There is occasionally a weird glitch that happens where the system thinks the due date key/value pair is incorrect on initial load and crashes the program, but running it again makes the error go away with no changes to code.

In terms of code coverage with unit tests, I have all of the code that does logic covered but there are a few areas my coverage claims aren't hit. If they really weren't hit however, the system wouldn't work. For instance, the ToString() in Task, shows it isn't hit. When I comment it out however, certain things don't work as they should and tests fail so I know it's being hit. The same issue exists with the RemoveTask() inside of TodoList, and the same reasoning exists for why that is actually covered. Not to mention that method is all of 4 lines that actually do something, and it reads 4/10 lines are hit by test when there's only 5 lines including the method name. The code coverage in VS 2019 doesn't ever seem to hit 100% for me, but it is very close in most cases and I can't actually see the lines that aren't being hit.

#### App Working Example or Current State Demonstration
https://user-images.githubusercontent.com/63754468/121624675-ca81bc00-ca26-11eb-98b1-ee780d64b92e.MP4
#### Instructions for Execution
Just follow the prompts and it should run just fine. Everything works from my side and I tried to catch all of the user side errors I could think of.

## Acknowledgements & Resources Used
Be sure to acknowledge and describe (cite) any resources (whether people or information) that you used to implement your app.
Please see the syllabus for academic integrity specifics, including examples of acceptable and unacceptable resources or actions.
