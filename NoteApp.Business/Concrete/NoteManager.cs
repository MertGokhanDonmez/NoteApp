using NoteApp.Business.Abstract;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.Business.Concrete;

public class NoteManager : IGenericService<Note>, INoteService
{
    INoteDal _noteDal;
    public NoteManager(INoteDal noteDal)
    {
        _noteDal = noteDal;
    }

    public void Delete(Note t)
    {
        _noteDal.Delete(t);
    }

    public List<Note> GetAll()
    {
        return _noteDal.GetAll();
    }

    public List<Note> GetAllNotesByUserId(int id)
    {
        return _noteDal.GetAll(p => p.UserId == id);
    }

    public Note GetById(int Id)
    {
        return _noteDal.GetById(p => p.NoteId == Id);
    }

    public void Insert(Note t)
    {
        _noteDal.Add(t);
    }

    public void Update(Note t)
    {
        _noteDal.Update(t);
    }
}
