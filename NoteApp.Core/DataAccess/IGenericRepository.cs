using System.Linq.Expressions;
using NoteApp.Core.Entities;

namespace NoteApp.Core.DataAccess;

public interface IGenericRepository<T> where T : class, IEntity, new()
{
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
