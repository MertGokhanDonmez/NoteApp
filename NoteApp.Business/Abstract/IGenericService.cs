using NoteApp.Core.Entities;

namespace NoteApp.Business.Abstract;

public interface IGenericService<T> where T : class, IEntity, new()
{
    List<T> GetAll();
    T GetById(int Id);
    void Update(T t);
    void Insert(T t);
    void Delete(T t);
}
