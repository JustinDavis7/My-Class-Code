namespace HW4.Models
{
    /// <summary>
    /// A TaskTodo is a helper model that holds information about a task that needs to be done.  It holds the task
    /// and the date on which it is scheduled to be done.  This date is based on the task's start date and interval.
    /// 
    /// Feel free to add to this if needed to use as a DTO
    /// </summary>
    public class TaskTodo
    {
        public ItemTask Todo { get; set; } = null!;
        public DateOnly TodoCalculatedDate { get; set; }
    }
}
