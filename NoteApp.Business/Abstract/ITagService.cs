using NoteApp.Business.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.Business;

public interface ITagService : IGenericService<Tag>
{
    List<Tag> GetAllTagsByUserId(int userId);

}
