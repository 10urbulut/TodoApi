using Core.DataAccess.EntityFramework;
using Todo.DataAccess.Abstract;
using Todo.Entities;

namespace Todo.DataAccess
{
    public class DailyTodoDal : EfEntityRepositoryBase<DailyTodo, DataBaseContext>, IDailyTodoDal
    {
    }
}
