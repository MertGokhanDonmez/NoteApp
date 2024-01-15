
using NoteApp.Core.Entities;

namespace NoteApp.Entities.Concrete;

public class User : IEntity
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public ICollection<Note> Notes { get; set; } = new List<Note>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
