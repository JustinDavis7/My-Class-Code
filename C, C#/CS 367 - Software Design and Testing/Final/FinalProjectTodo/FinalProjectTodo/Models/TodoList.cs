using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = FinalProjectTodo.Models.Task;

namespace FinalProjectTodo.Models
{
    public class TodoList : Lists
    {
        public void RemoveTask(Task taskToRemove)
        {
            foreach (var task in Tasks.Where(task => task.Equals(taskToRemove)))
            {
                Tasks.Remove(task);
                break;
            }
        }

        public static void WriteTodo(TodoList todo, string fileName)
        {
            var write = todo.ToString();
            File.WriteAllText(fileName, write);
        }

        public void UpdateTask(int taskIndex, CompletedList completed, string newPriority, string newProjectTags, string newContextTags, 
            string newCompletionMarker, string newDueDate, string newCreationDate, string newCompletionDate, string fileName)
        {
            var done = false;
            Task updatedTask = null;
            if (newPriority != "null")
            {
                Tasks[taskIndex].Priority = newPriority;
            }

            if (newProjectTags != "null")
            {
                var split = newProjectTags.Split(" ");
                var projectTags = split.ToList();
                Tasks[taskIndex].ProjectTag = projectTags;
            }

            if (newContextTags != "null")
            {
                var split = newContextTags.Split(" ");
                var contextTags = split.ToList();
                Tasks[taskIndex].ContextTag = contextTags;
            }

            if (newCompletionMarker != "null")
            {
                if (newCompletionMarker == "x")
                    done = true;
                updatedTask = new Task(Tasks[taskIndex])
                {
                    CompletionStatus = "x"
                };
                Tasks[taskIndex].CompletionStatus = newCompletionMarker;
            }

            if (newDueDate != "null")
            {
                var split = newDueDate.Split(':');
                Tasks[taskIndex].DueDate = new Dictionary<string, string>
                {
                    { split[0], split[1] }
                };
            }

            if (newCreationDate != "null")
            {
                Tasks[taskIndex].CreationDate = newCreationDate;
            }

            if (newCompletionDate != "null")
            {
                Tasks[taskIndex].CompletionDate = newCompletionDate;
            }

            if (done)
            {
                Console.WriteLine("Congrats on finishing your task!");
                RemoveTask(updatedTask);
                completed.Add(updatedTask);
                CompletedList.WriteCompleted(completed, fileName);
                return;
            }
            Console.WriteLine("Your task has been updated!");
        }
    }
}
