using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteApp.Core.DataAccess;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class EfTagDal : IGenericRepository<Tag>, ITagDal
{
    public void Add(Tag entity)
    {
        using (Context context = new Context())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Tag entity)
    {
        using (Context context = new Context())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public Tag GetById(Expression<Func<Tag, bool>> filter)
    {
        using (Context context = new Context())
        {
            return context.Set<Tag>().SingleOrDefault(filter);
        }
    }

    public List<Tag> GetAll(Expression<Func<Tag, bool>> filter = null)
    {
        using (Context context = new Context())
        {
            return filter == null ? context.Set<Tag>().Where(filter).ToList() : context.Set<Tag>().ToList();
        }
    }

    public void Update(Tag entity)
    {
        using (Context context = new Context())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
