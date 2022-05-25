using Core.DataAccess.EntityFramework;
using Todo.DataAccess.Abstract;
using Todo.Models;

namespace Todo.DataAccess.Concrete
{
    public class UserDal: EfEntityRepositoryBase<User, DatabaseContext>, IUserDal
    {      
    }
}

