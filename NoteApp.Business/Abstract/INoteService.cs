using NoteApp.Entities.Concrete;

namespace NoteApp.Business.Abstract;

public interface INoteService : IGenericService<Note>
{
    List<Note> GetAllNotesByUserId(int userId);
}
