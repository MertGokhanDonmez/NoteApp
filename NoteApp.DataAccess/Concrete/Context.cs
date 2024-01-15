using Microsoft.EntityFrameworkCore;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class Context : DbContext
{ 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost; Database=NoteProjectDb; user id=sa; password=538647MgD*; TrustServerCertificate=True");
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
}
