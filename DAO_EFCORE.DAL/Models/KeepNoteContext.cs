using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAO_EFCORE.DAL.Models
{
    public class KeepNoteContext : DbContext, IKeepNoteContext
    {
        public KeepNoteContext(DbContextOptions<KeepNoteContext> options)
           : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbContext Instance => this;

        //Fluent API to configure relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasMany(n => n.ListItems).WithOne(c => c.Note).HasForeignKey(n => n.ChecklistId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Note>().HasMany(n => n.Labels).WithOne(c => c.Note).HasForeignKey(n => n.LabelId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Label>().HasOne(l => l.Note).WithMany(n => n.Labels).HasForeignKey(l => l.NoteId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Checklist>().HasOne(l => l.Note).WithMany(n => n.ListItems).HasForeignKey(l => l.NoteId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
