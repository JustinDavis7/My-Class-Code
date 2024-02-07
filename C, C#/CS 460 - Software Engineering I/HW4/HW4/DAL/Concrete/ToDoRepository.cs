using System;
using System.Collections.Generic;
using System.Linq;
using HW4.Models;
using HW4.DAL.Abstract;

namespace HW4.DAL.Concrete 
{
    public class ToDoRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        public ToDoRepository(ToDoDbContext ctx) : base(ctx)
        { }
    }
}