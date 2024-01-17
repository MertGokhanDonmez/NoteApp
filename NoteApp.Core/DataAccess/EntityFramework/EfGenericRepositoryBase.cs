using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteApp.Core.DataAccess;
using NoteApp.Core.Entities;

namespace NoteApp.Core.EntityFramework;

public class EfGenericRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using (TContext context = new TContext())
        {
            return filter == null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();
        }
    }

    public TEntity GetById(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public void Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
