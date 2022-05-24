using Todo.Core.Utilities.Results.DataResult;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;


namespace Todo.Business.Abstract
{
    public interface IWeeklyTodoService
    {
        IDataResult<List<WeeklyTodo>> GetAll();
        IDataResult<WeeklyTodo> GetById(int weeklyTodoId);
        IResult Add(WeeklyTodo weeklyTodo);
        IResult Update(WeeklyTodo weeklyTodo);
        IResult Delete(WeeklyTodo weeklyTodo);
    }
}
