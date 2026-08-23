using Microsoft.EntityFrameworkCore;
using Kanban.Models;

namespace Kanban.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<CardRole> CardRoles { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>()
            .HasOne(u => u.Owner).WithMany(p => p.OwnedProjects).HasForeignKey(u => u.OwnerId);

        modelBuilder.Entity<Project>()
            .HasMany(p => p.Collaborators).WithMany(c => c.CollaboratingProjects);
        
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Favorites).WithMany(c => c.FavoriteProjects);
        
        
        
        modelBuilder.Entity<CardRole>()
            .HasKey(k => new { k.CardId, k.RoleId });
        modelBuilder.Entity<CardRole>()
            .HasOne(rc => rc.Role).WithMany(r => r.CardPermission).HasForeignKey(rc => rc.RoleId);
        modelBuilder.Entity<CardRole>()
            .HasOne(rc => rc.Card).WithMany(c => c.CardRole).HasForeignKey(rc => rc.CardId);
        
        
        
    }
}