using Microsoft.EntityFrameworkCore;
using Todo.Entities;

namespace Todo.DataAccess
{
    public class DataBaseContext:DbContext
    {
        public DbSet<DailyTodo>? DailyTodos { get; set; }
        public DbSet<WeeklyTodo>? WeeklyTodos{ get; set; }
        public DbSet<MonthlyTodo>? MonthlyTodos { get; set; }
    }
}
