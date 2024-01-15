using NoteApp.Business.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.Business;

public class UserManager : IGenericService<User>, IUserService
{
    public void Delete(User t)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public void Insert(User t)
    {
        throw new NotImplementedException();
    }

    public void Update(User t)
    {
        throw new NotImplementedException();
    }
}
