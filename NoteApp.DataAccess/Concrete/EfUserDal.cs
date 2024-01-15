using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteApp.Core.DataAccess;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class EfUserDal : IGenericRepository<User>, IUserDal
{
    public void Add(User entity)
    {
        using (Context context = new Context())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(User entity)
    {
        using (Context context = new Context())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public List<User> GetAll(Expression<Func<User, bool>> filter = null)
    {
        using (Context context = new Context())
        {
            return filter == null ? context.Set<User>().Where(filter).ToList() : context.Set<User>().ToList();
        }
    }

    public User GetById(Expression<Func<User, bool>> filter)
    {
        using (Context context = new Context())
        {
            return context.Set<User>().SingleOrDefault(filter);
        }
    }

    public void Update(User entity)
    {
        using (Context context = new Context())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
