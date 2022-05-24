using Todo.Core.Utilities.Results.DataResult;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;


namespace Todo.Business.Abstract
{
    public interface IMonthlyTodoService
    {
        IDataResult<List<MonthlyTodo>> GetAll();
        IDataResult<MonthlyTodo> GetById(int monthlyTodoId);
        IResult Add(MonthlyTodo monthlyTodo);
        IResult Update(MonthlyTodo monthlyTodo);
        IResult Delete(MonthlyTodo monthlyTodo);
    }
}
