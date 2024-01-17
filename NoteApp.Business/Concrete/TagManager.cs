using NoteApp.Business.Abstract;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.Business.Concrete;

public class TagManager : IGenericService<Tag>, ITagService
{
    ITagDal _tagDal;
    public TagManager(ITagDal tagDal)
    {
        _tagDal = tagDal;
    }
    public void Delete(Tag t)
    {
        _tagDal.Delete(t);
    }

    public List<Tag> GetAll()
    {
        return _tagDal.GetAll();
    }

    public Tag GetById(int Id)
    {
        return _tagDal.Get(p => p.TagId == Id);
    }

    public void Insert(Tag t)
    {
        _tagDal.Add(t);
    }

    public void Update(Tag t)
    {
        _tagDal.Update(t);
    }
}
