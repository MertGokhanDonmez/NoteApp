
using NoteApp.Core.Entities;

namespace NoteApp.Entities.Concrete;

public class Note : IEntity
{
    public int NoteId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<NoteTag> NoteTags { get; set; }
}