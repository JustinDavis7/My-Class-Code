using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTodo.Models
{
    public class CompletedList : Lists
    {
        public static void WriteCompleted(CompletedList completed, string fileName)
        {
            var write = completed.ToString();
            File.WriteAllText(fileName, write);
        }
        public override string ToString()
        {
            var completionDate = this.Tasks.Select(task => task.CompletionDate).ToList();
            completionDate.Sort();
            completionDate.Reverse();
            var tasksList = GetStringList();

            var a = new string[completionDate.Count];
            foreach (var task in tasksList)
            {
                for (var index = 0; index < completionDate.Count; index++)
                {
                    var split = task.Split(" ");
                    if (completionDate[index] != null && split[1] == completionDate[index])
                    {
                        a[index] = task;
                        completionDate[index] = null;
                    }
                }
            }
            return a.Aggregate("", (current, task) => current + ("x " + task));
        }
    }
}
