using NoteApp.Core.DataAccess;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess.Abstract;

public interface IUserDal : IGenericRepository<User>
{
    //custom methods for User entity
}
