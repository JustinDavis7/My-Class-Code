using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task = FinalProjectTodo.Models.Task;

namespace FinalProjectTodo.Models
{
    public abstract class Lists
    { 
        public List<Task> Tasks;
        public void InitializeTodo(string fileName)
        {
            Tasks = new List<Task>();
            if (File.Exists(fileName))
            {
                var data = File.ReadAllLines(fileName);
                foreach (var task in data)
                {
                    var completionStatus = "";
                    if (task.StartsWith('x'))
                    {
                        completionStatus = "x";
                    }
                    var projectTags = new List<string>();
                    var dueDate = new Dictionary<string, string>();
                    var contextTags = new List<string>();
                    var splitData = task.Split(" ");
                    foreach (var item in splitData)
                    {
                        if (item.StartsWith('@'))
                        {
                            contextTags.Add(item);
                        }
                        if (item.StartsWith('+'))
                        {
                            projectTags.Add(item);
                        }
                    }

                    var splitDueDate = splitData[^1].Split(':');
                    dueDate.Add(splitDueDate[0], splitDueDate[1]);

                    if(completionStatus == "x")
                        this.Add(new Task(completionStatus, splitData[1], splitData[2], splitData[3], projectTags,
                            contextTags, dueDate));
                    else
                        Tasks.Add(new Task( completionStatus, splitData[0], splitData[1], splitData[2], projectTags,
                            contextTags, dueDate));
                }
                Console.WriteLine($"The file was found! Using {fileName}.");
            }
            else
            {
                File.WriteAllText(fileName, "");
                Console.WriteLine($"A text file has been created at {fileName}.");
            }
        }

        public void Add(Task taskToAdd)
        {
            Tasks.Add(taskToAdd);
        }

        public override string ToString()
        {
            var tasksString = "";
            if (Tasks.Count <= 0) return "";
            foreach (var task in Tasks)
            {
                var projectTag = "";
                var contextTag = "";
                var key = "";
                var value = "";
                var completion = "";
                projectTag = task.ProjectTag.Aggregate(projectTag, (current, tag) => current + (tag + " "));
                contextTag = task.ContextTag.Aggregate(contextTag, (current, tag) => current + (tag + " "));

                foreach (var (s, value1) in task.DueDate)
                {
                    key = s;
                    value = value1;
                }

                if (task.CompletionDate != "null")
                {
                    completion = task.CompletionDate;
                }

                tasksString +=
                    $"{task.Priority} {completion} {task.CreationDate} {projectTag} {contextTag} {key}:{value}\n";
            }
            return tasksString;
        }
        public string ToStringPriority()
        {
            var priorities = Tasks.Select(task => task.Priority[1]).ToList();
            priorities.Sort();
            var tasksList = GetStringList();
            var a = new string[priorities.Count];
            foreach (var task in tasksList)
            {
                for (var index = 0; index < priorities.Count; index++)
                {
                    if (priorities[index] == '0' || task[1] != priorities[index]) continue;
                    a[index] = task;
                    priorities[index] = '0';
                }
            }

            return a.Aggregate("", (current, task) => current + task);
        }

        public string ToStringProjectTag()
        {
            var projectTag = new List<string>();
            var i = 0;
            foreach (var task in Tasks)
            {
                var temp = "";
                foreach (var tag in task.ProjectTag)
                    temp += tag + " ";
                projectTag.Add(temp);
            }
            projectTag.Sort();
            var tasksList = GetStringList();
            var a = new string[projectTag.Count];
            foreach (var task in tasksList)
            {
                for (var index = 0; index < projectTag.Count; index++)
                {
                    var split = task.Split(" ");
                    var temp = "";
                    foreach(var piece in split)
                        if (piece.Contains("+"))
                            temp += piece + " ";
                    temp.Trim();
                    if (projectTag[index] != null && temp == projectTag[index])
                    {
                        a[index] = task;
                        projectTag[index] = null;
                    }
                }
            }
            return a.Aggregate("", (current, task) => current + task);
        }

        public string ToStringContextTag()
        {
            var contextTag = new List<string>();
            var i = 0;
            foreach (var task in Tasks)
            {
                var temp = "";
                foreach (var tag in task.ContextTag)
                    temp += tag + " ";
                contextTag.Add(temp);
            }
            contextTag.Sort();
            var tasksList = GetStringList();
            var a = new string[contextTag.Count];
            foreach (var task in tasksList)
            {
                for (var index = 0; index < contextTag.Count; index++)
                {
                    var split = task.Split(" ");
                    var temp = split.Where(piece => piece.Contains("@")).Aggregate("", (current, piece) => current + (piece + " "));
                    if (contextTag[index] != null && temp.TrimStart('@').Equals(contextTag[index].TrimStart('@')))
                    {
                        a[index] = task;
                        contextTag[index] = null;
                    }
                }
            }
            return a.Aggregate("", (current, task) => current + task);
        }

        public IEnumerable<string> GetStringList()
        {
            var tasksList = new List<string>();
            foreach (var task in Tasks)
            {
                var projectTag = "";
                var contextTag = "";
                var key = "";
                var value = "";
                var completion = "";
                projectTag = task.ProjectTag.Aggregate(projectTag, (current, tag) => current + (tag + " "));
                contextTag = task.ContextTag.Aggregate(contextTag, (current, tag) => current + (tag + " "));

                foreach (var (s, value1) in task.DueDate)
                {
                    key = s;
                    value = value1;
                }

                if (task.CompletionDate != "null")
                {
                    completion = task.CompletionDate;
                }

                tasksList.Add(
                    $"{task.Priority} {completion} {task.CreationDate} {projectTag.Trim()} {contextTag.Trim()} {key}:{value}\n");
            }

            return tasksList;
        }
    }
}
