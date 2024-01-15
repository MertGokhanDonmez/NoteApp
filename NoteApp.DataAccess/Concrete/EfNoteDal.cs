using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteApp.Core.DataAccess;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class EfNoteDal : IGenericRepository<Note>, INoteDal
{
    public void Add(Note entity)
    {
        using (Context context = new Context())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Note entity)
    {
        using (Context context = new Context())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public List<Note> GetAll(Expression<Func<Note, bool>> filter = null)
    {
        using (Context context = new Context())
        {
            return filter == null ? context.Set<Note>().Where(filter).ToList() : context.Set<Note>().ToList();
        }
    }

    public Note GetById(Expression<Func<Note, bool>> filter)
    {
        using (Context context = new Context())
        {
            return context.Set<Note>().SingleOrDefault(filter);
        }
    }

    public void Update(Note entity)
    {
        using (Context context = new Context())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
