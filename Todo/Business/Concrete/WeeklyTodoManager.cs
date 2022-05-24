using Todo.Business.Abstract;
using Todo.Core;
using Todo.Core.Utilities.Results;
using Todo.Core.Utilities.Results.DataResult;
using Todo.DataAccess.Abstract;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Business.Concrete
{
    public class WeeklyTodoManager : IWeeklyTodoService
    {
        IWeeklyTodoDal _weeklyTodoDal;

        public WeeklyTodoManager(IWeeklyTodoDal weeklyTodoDal)
        {
            _weeklyTodoDal = weeklyTodoDal;
        }

        public IResult Add(WeeklyTodo weeklyTodo)
        {
            if (weeklyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }
            weeklyTodo.TodoStatus = Status.Pending;
            weeklyTodo.CreatedAt = DateTime.Now;
            _weeklyTodoDal.Add(weeklyTodo);
            return new SuccessResult(ConstantStrings.EKLENDI);
        }


        public IResult Delete(WeeklyTodo weeklyTodo)
        {
            if (weeklyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }

            _weeklyTodoDal.Delete(weeklyTodo);
            return new SuccessResult(ConstantStrings.SILINDI);
        }


        public IDataResult<List<WeeklyTodo>> GetAll()
        {
            return new SuccessDataResult<List<WeeklyTodo>>(_weeklyTodoDal.GetAll());
        }


        public IDataResult<WeeklyTodo> GetById(int weeklyTodoId)
        {
            return new SuccessDataResult<WeeklyTodo>(_weeklyTodoDal.Get(dt => dt.Id == weeklyTodoId));
        }



        public IResult Update(WeeklyTodo weeklyTodo)
        {
            if (weeklyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }
            weeklyTodo.UpdatedAt = DateTime.Now;
            _weeklyTodoDal.Update(weeklyTodo);
            return new SuccessResult(ConstantStrings.GUNCELLENDI);
        }
    }
}
