using NoteApp.Business.Abstract;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.Business.Concrete;

public class UserManager : IGenericService<User>, IUserService
{
    IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    public void Delete(User t)
    {
        _userDal.Delete(t);
    }

    public List<User> GetAll()
    {
        return _userDal.GetAll();
    }

    public User GetById(int Id)
    {
        return _userDal.Get(p => p.UserId == Id);
    }

    public void Insert(User t)
    {
        _userDal.Add(t);
    }

    public void Update(User t)
    {
        _userDal.Update(t);
    }
}
