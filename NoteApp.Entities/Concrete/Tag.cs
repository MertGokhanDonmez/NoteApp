using NoteApp.Core.Entities;

namespace NoteApp.Entities.Concrete;

public class Tag : IEntity
{
    public int TagId { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public AppUser User { get; set; }
    public ICollection<NoteTag> NoteTags { get; set; } = new List<NoteTag>();
}