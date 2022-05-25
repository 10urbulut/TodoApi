using Core.DataAccess.EntityFramework;
using Todo.DataAccess.Abstract;
using Todo.Entities;

namespace Todo.DataAccess.Concrete
{
    public class WeeklyTodoDal : EfEntityRepositoryBase<WeeklyTodo, DatabaseContext>, IWeeklyTodoDal
    {
    }
}
