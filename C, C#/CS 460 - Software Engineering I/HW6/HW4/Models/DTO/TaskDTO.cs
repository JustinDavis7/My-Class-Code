namespace HW4.Models.DTO
{
    #nullable disable
    public class TaskDTO
    {
        public string name {get; set;}
        public string notes {get; set;}
        public DateTime firstCompletion {get; set;}
        public TaskDTO(TaskTodo task)
        {
            name = task.Todo.Name;
            notes = task.Todo.Notes;
            firstCompletion = new DateTime(task.TodoCalculatedDate.Year, task.TodoCalculatedDate.Month, task.TodoCalculatedDate.Day);
        }
    }
}