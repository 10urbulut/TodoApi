using Microsoft.EntityFrameworkCore;
using Todo.Entities;
using Todo.Models;

namespace Todo.DataAccess
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Todo;Trusted_Connection=True;");
        }

        public DbSet<DailyTodo>? DailyTodos { get; set; }
        public DbSet<WeeklyTodo>? WeeklyTodos{ get; set; }
        public DbSet<MonthlyTodo>? MonthlyTodos { get; set; }
        public DbSet<User>? Users{ get; set; }
    }
}
