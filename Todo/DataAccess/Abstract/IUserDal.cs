using Todo.Core;
using Todo.Models;

namespace Todo.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
