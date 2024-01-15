using NoteApp.Core.DataAccess;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess.Abstract;

public interface ITagDal : IGenericRepository<Tag>
{
    //custom methods for Tag entity
}
