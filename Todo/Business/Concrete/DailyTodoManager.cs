using Todo.Business.Abstract;
using Todo.Core;
using Todo.Core.Utilities.Results;
using Todo.Core.Utilities.Results.DataResult;
using Todo.DataAccess.Abstract;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Business.Concrete
{
    public class DailyTodoManager : IDailyTodoService
    {
        IDailyTodoDal _dailyTodoDal;

        public DailyTodoManager(IDailyTodoDal dailyTodoDal)
        {
            _dailyTodoDal = dailyTodoDal;
        }

        public IResult Add(DailyTodo dailyTodo)
        {
            if (dailyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }
            dailyTodo.TodoStatus = Status.Pending;
            dailyTodo.CreatedAt=DateTime.Now;
            _dailyTodoDal.Add(dailyTodo);
            return new SuccessResult(ConstantStrings.EKLENDI);
        }


        public IResult Delete(DailyTodo dailyTodo)
        {
            if (dailyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }

            _dailyTodoDal.Delete(dailyTodo);
            return new SuccessResult(ConstantStrings.SILINDI);
        }


        public IDataResult<List<DailyTodo>> GetAll()
        {
            return new SuccessDataResult<List<DailyTodo>>(_dailyTodoDal.GetAll());
        }


        public IDataResult<DailyTodo> GetById(int dailyTodoId)
        {
            return new SuccessDataResult<DailyTodo>(_dailyTodoDal.Get(dt => dt.Id == dailyTodoId));
        }

      

        public IResult Update(DailyTodo dailyTodo)
        {
            if (dailyTodo is null)
            {
                return new ErrorResult(ConstantStrings.BASARISIZ);
            }
            dailyTodo.UpdatedAt=DateTime.Now;
            _dailyTodoDal.Update(dailyTodo);
            return new SuccessResult(ConstantStrings.GUNCELLENDI);
        }
    }
}
