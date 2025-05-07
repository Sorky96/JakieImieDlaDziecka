using Models;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=DefaultConnection")
    {
    }

    public DbSet<NameRecord> NameRecords { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<NameRecord>()
            .HasKey(e => e.Id)
            .Property(e => e.Name).IsRequired().HasMaxLength(100);

        modelBuilder.Entity<NameRecord>()
            .Property(e => e.Gender).IsRequired();

        modelBuilder.Entity<NameRecord>()
            .Property(e => e.Year).IsRequired();

        modelBuilder.Entity<NameRecord>()
            .Property(e => e.Count).IsRequired();
    }
}