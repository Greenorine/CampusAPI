using Campus.Db.Entities;
using Campus.Db.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Campus.Db;

public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) :
        base(options)
    {
        this.httpContextAccessor = httpContextAccessor;

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntity && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            var entity = (IEntity)entityEntry.Entity;
            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedOn = DateTime.UtcNow;
                entity.CreatedBy = httpContextAccessor?.HttpContext?.User.Identity?.Name ?? "Admin";
            }
            else
            {
                Entry(entity).Property(p => p.CreatedOn).IsModified = false;
                Entry(entity).Property(p => p.CreatedBy).IsModified = false;
            }

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy =
                httpContextAccessor?.HttpContext?.User.Identity?.Name ?? "Admin";
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<StudentInfo> StudentInfo { get; set; }
    public DbSet<TeacherInfo> TeacherInfo { get; set; }
    public DbSet<Activity> Activities { get; set; }
}