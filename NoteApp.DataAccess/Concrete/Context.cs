using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class Context : IdentityDbContext<AppUser, AppRole, int>
{ 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("your connection string");
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<NoteTag> NoteTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<NoteTag>()
            .HasKey(nt => new { nt.NoteId, nt.TagId });

        modelBuilder.Entity<NoteTag>()
            .HasOne(nt => nt.Note)
            .WithMany(n => n.NoteTags)
            .HasForeignKey(nt => nt.NoteId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<NoteTag>()
            .HasOne(nt => nt.Tag)
            .WithMany(t => t.NoteTags)
            .HasForeignKey(nt => nt.TagId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Note>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notes)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Tag>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tags)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
