namespace NoteApp.Api.Models;

public class NoteModel
{
    public int NoteId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
}
