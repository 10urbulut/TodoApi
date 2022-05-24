using Todo.Models;

namespace Todo.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);
    }
}
