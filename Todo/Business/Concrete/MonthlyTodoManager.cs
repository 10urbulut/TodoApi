using Todo.Business.Abstract;
using Todo.Core;
using Todo.Core.Utilities.Results;
using Todo.Core.Utilities.Results.DataResult;
using Todo.DataAccess.Abstract;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Business.Concrete
{
    public class MonthlyTodoManager : IMonthlyTodoService
    {
        IMonthlyTodoDal _monthlyTodoDal;

        public MonthlyTodoManager(IMonthlyTodoDal monthlyTodoDal)
        {
            _monthlyTodoDal = monthlyTodoDal;
        }

        public IResult Add(MonthlyTodo monthlyTodo)
        {
            if (monthlyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }
            monthlyTodo.TodoStatus = Status.Pending;
            monthlyTodo.CreatedAt = DateTime.Now;
            _monthlyTodoDal.Add(monthlyTodo);
            return new SuccessResult(ConstantStrings.EKLENDI);
        }


        public IResult Delete(MonthlyTodo monthlyTodo)
        {
            if (monthlyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }

            _monthlyTodoDal.Delete(monthlyTodo);
            return new SuccessResult(ConstantStrings.SILINDI);
        }
        public IDataResult<List<MonthlyTodo>> GetAll()
        {
            return new SuccessDataResult<List<MonthlyTodo>>(_monthlyTodoDal.GetAll());
        }


        public IDataResult<MonthlyTodo> GetById(int monthlyTodoId)
        {
            return new SuccessDataResult<MonthlyTodo>(_monthlyTodoDal.Get(dt => dt.Id == monthlyTodoId));
        }



        public IResult Update(MonthlyTodo monthlyTodo)
        {
            if (monthlyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }
            monthlyTodo.UpdatedAt = DateTime.Now;
            _monthlyTodoDal.Update(monthlyTodo);
            return new SuccessResult(ConstantStrings.GUNCELLENDI);
        }
    }
}
