using HW6.DAL.Abstract;
using HW6.Models;

namespace HW6.DAL.Concrete
{
    public class StaskRepository : Repository<Stask>, IStaskRepository
    {
        public StaskRepository(RemindersDbContext ctx) : base(ctx)
        {

        }

        public List<TaskTodo> GetAllTasksTodoWithinTimeWindow(DateOnly today, int days)
        {
            throw new NotImplementedException();
        }
    }
}
