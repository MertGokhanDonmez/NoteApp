using NoteApp.Core.DataAccess;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess.Abstract;

public interface INoteDal : IGenericRepository<Note>
{

}
