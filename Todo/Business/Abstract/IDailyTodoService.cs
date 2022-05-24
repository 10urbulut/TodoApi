using Todo.Core.Utilities.Results.DataResult;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Business.Abstract
{
    public interface IDailyTodoService
    {
        IDataResult<List<DailyTodo>> GetAll();
        IDataResult<DailyTodo> GetById(int dailyTodoId);
        IResult Add(DailyTodo dailyTodo);
        IResult Update(DailyTodo dailyTodo);
        IResult Delete(DailyTodo dailyTodo);
    }
}
