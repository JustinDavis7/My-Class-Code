using HW4.DAL.Abstract;
using HW4.Models;

namespace HW4.DAL.Concrete
{
    public class ToDoTaskRepository : Repository<ItemTask>, IToDoTaskRepository
    {
        public ToDoTaskRepository(ToDoDbContext ctx) : base(ctx)
        {

        }

        public List<TaskTodo> GetAllTasksTodoWithinTimeWindow(DateOnly today, int days)
        {
            var tasks = GetAll().ToList();
            var tasksInWindow = new List<TaskTodo>();
            var timeRange = today.AddDays(days);

            foreach(var task in tasks)
            {
                var onlyDate = new DateOnly(task.FirstCompletion.Year, task.FirstCompletion.Month, task.FirstCompletion.Day);
                while (onlyDate <= timeRange)
                {
                    if(onlyDate >= today)
                    {
                        tasksInWindow.Add(new TaskTodo {Todo = task, TodoCalculatedDate = onlyDate});
                        onlyDate = onlyDate.AddDays(task.Frequency);
                    }
                    else if (onlyDate.AddDays(task.Frequency) >= today)
                    {
                        onlyDate = onlyDate.AddDays(task.Frequency);
                    }
                    else
                    {
                        onlyDate = onlyDate.AddDays(task.Frequency);
                    }
                }
            }
            tasksInWindow = tasksInWindow.OrderBy(t => t.TodoCalculatedDate).ToList();
            return tasksInWindow;
        }
    }
}
