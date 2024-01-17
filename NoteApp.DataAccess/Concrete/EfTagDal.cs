using NoteApp.Core.EntityFramework;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class EfTagDal : EfGenericRepositoryBase<Tag, Context>, ITagDal
{
    
}
