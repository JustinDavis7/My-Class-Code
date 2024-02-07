using System.Collections.Generic;
using System.Linq;

namespace FinalProjectTodo.Models
{

    public class Task
    {
        public string CompletionStatus { get; set; }
        public string Priority { get; set; }
        public string CompletionDate { get; set; }
        public string CreationDate { get; set; }
        public List<string> ProjectTag { get; set; }
        public List<string> ContextTag { get; set; }
        public Dictionary<string, string> DueDate { get; set; }

        public Task(Task task)
        {
            if (task.CompletionDate == null)
            {
                CompletionDate = "";
            }
            else
            {
                CompletionStatus = task.CompletionStatus;
                Priority = task.Priority;
                CompletionDate = task.CompletionDate;
                CreationDate = task.CreationDate;
                ProjectTag = task.ProjectTag;
                ContextTag = task.ContextTag;
                DueDate = task.DueDate;
            }
        }

        public Task(string completionStatus, string priority, string completionDate, string creationDate,
            List<string> projectTag, List<string> contextTag, Dictionary<string, string> dueDate)
        {
            if (completionStatus == null)
            {
                CompletionDate = "";
            }
            else
            {
                CompletionStatus = completionStatus;
                Priority = priority;
                CompletionDate = completionDate;
                CreationDate = creationDate;
                ProjectTag = projectTag;
                ContextTag = contextTag;
                DueDate = dueDate;
            }
        }

        public bool Equals(Task taskToCheck)
        {
            return (taskToCheck.Priority == this.Priority && taskToCheck.CompletionDate == this.CompletionDate &&
                    taskToCheck.DueDate == this.DueDate && taskToCheck.ProjectTag == this.ProjectTag
                    && taskToCheck.ContextTag == this.ContextTag);
        }

        public override string ToString()
        {
            var tasksString = "";
            var projectTag = "";
            var contextTag = "";
            var key = "";
            var value = "";
            var completion = "";
            projectTag = this.ProjectTag.Aggregate(projectTag, (current, tag) => current + (tag + " "));
            contextTag = this.ContextTag.Aggregate(contextTag, (current, tag) => current + (tag + " "));

            foreach (var (s, value1) in this.DueDate)
            {
                key = s;
                value = value1;
            }

            if (this.CompletionDate != "null")
            {
                completion = this.CompletionDate;
            }

            tasksString +=
                $"{this.Priority} {completion} {this.CreationDate} {projectTag} {contextTag} {key}:{value}\n";
            return tasksString;
        }
    }
}
