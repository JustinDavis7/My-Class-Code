using System;
using System.Collections.Generic;
using System.Linq;
using FinalProjectTodo.Models;

namespace FinalProjectTodo.StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuChoice = 100;
            Console.WriteLine("Enter the file name:");
            string file = Console.ReadLine();
            var todo = new TodoList();
            var completed = new CompletedList();
            todo.InitializeTodo(file);
            completed.InitializeTodo("completed" + file);

            do
            {
                var pass = false;
                do
                {
                    Console.WriteLine("\n\nWhich action would you like to perform?");
                    Console.WriteLine(
                        "1.Add Todo Item\n2.See Todo List Order By Priority\n3.See Todo List Order By Choice\n" +
                        "4.See Completed List Order By Descending Completion Date\n5.Update Todo Item\n6.Quit");
                    try
                    {
                        menuChoice = Convert.ToInt32(Console.ReadLine());
                        pass = true;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input.");
                    }
                } while (!pass);

                Console.Clear();
                pass = false;
                switch (menuChoice)
                { 
                    case 1:
                        string[] split = null;
                        var dict = new Dictionary<string, string>();
                        string dueDate;
                        Console.WriteLine("Please enter the priority as (A): ");
                        var priority = Console.ReadLine();

                        Console.WriteLine("Please enter the project tags (+tag1 +tag2):");
                        var projectTags = Console.ReadLine();

                        Console.WriteLine("Please enter the context tags (@tag1 @tag2):");
                        var contextTags = Console.ReadLine();

                        Console.WriteLine("Please enter the completion marker (x means you completed it):");
                        var completionMarker = Console.ReadLine()?.ToLower();

                        do
                        {
                            Console.WriteLine("Please enter the due date (due:2021-06-10):");
                            dueDate = Console.ReadLine();
                            if(!dueDate.Contains(":"))
                                Console.WriteLine("Your due date needs to have a key/value pair (due:xxx).");
                        } while (!dueDate.Contains(":"));
                        
                        split = dueDate.Split(':');
                        dict.Add(split[0], split[1]);
 
                        Console.WriteLine("Please enter the creation date:");
                        var creationDate = Console.ReadLine();

                        Console.WriteLine("Please enter the completion date:");
                        var completionDate = Console.ReadLine();

                        split = contextTags.Split(" ");
                        var contextTagsList = split.ToList();

                        split = projectTags.Split(" ");
                        var projectTagsList = split.ToList();

                        todo.Add(new Task(completionMarker, priority, completionDate, creationDate, projectTagsList, contextTagsList, dict));

                        Console.WriteLine(todo);
                        TodoList.WriteTodo(todo, file);

                        break;
                    case 2:
                        Console.WriteLine(todo.ToStringPriority());
                        break;
                    case 3:
                        var choice = 0;
                        pass = false;
                        do
                        {
                            Console.WriteLine("Which would you like to order the list by? (1.Priority, 2.Project Tag, 3.Context Tag)");
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                                if(choice is 1 or 2 or 3)
                                    pass = true;
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("That's not a valid entry. Please enter 1,2, or 3.");
                                }
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("That's not a valid entry. Please enter 1,2, or 3.");
                            }
                        } while (!pass);
                        Console.Clear();
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine(todo.ToStringPriority());
                                break;
                            case 2:
                                Console.WriteLine(todo.ToStringProjectTag());
                                break;
                            case 3:
                                Console.WriteLine(todo.ToStringContextTag());
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine(completed);
                        break;
                    case 5:
                        int taskIndex;
                        do
                        {
                            Console.WriteLine("Which task do you want to update?");
                            Console.WriteLine(todo);
                            taskIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (taskIndex > todo.Tasks.Count || taskIndex < 0)
                            {
                                pass = false;
                                Console.Clear();
                                Console.WriteLine("That index is out of range!\n");
                            }
                            else
                                pass = true;
                        } while (!pass);
                        Console.Clear();
                        var task = todo.Tasks[taskIndex];
                        Console.WriteLine($"The task you wish to edit is: {task}");
                        Console.WriteLine(
                            "If you don't wish to update a part, type \"null\" and it will be ignored.\nPlease enter the updated priority:");
                        var newPriority = Console.ReadLine();

                        Console.WriteLine("Please enter the updated project tags (+tag1 +tag2):");
                        var newProjectTags = Console.ReadLine();

                        Console.WriteLine("Please enter the updated context tags (@tag1 @tag2):");
                        var newContextTags = Console.ReadLine();

                        Console.WriteLine("Please enter the updated completion marker (x means you completed it):");
                        var newCompletionMarker = Console.ReadLine()?.ToLower();

                        Console.WriteLine("Please enter the updated due date (due:2021-06-10):");
                        var newDueDate = Console.ReadLine();

                        Console.WriteLine("Please enter the updated creation date:");
                        var newCreationDate = Console.ReadLine();

                        Console.WriteLine("Please enter the updated completion date:");
                        var newCompletionDate = Console.ReadLine();

                        todo.UpdateTask(taskIndex, completed, newPriority, newProjectTags, newContextTags,
                            newCompletionMarker, newDueDate, newCreationDate, newCompletionDate, "completed" + file);

                        TodoList.WriteTodo(todo, file);

                        break;
                }
            } while (menuChoice != 6);
        }
    }
}