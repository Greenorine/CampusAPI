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
            .Where(e => e.Entity is IEntity &&
                        e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);

        foreach (var entityEntry in entries)
        {
            var entity = (IEntity) entityEntry.Entity;
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreatedOn = DateTime.UtcNow;
                    entity.CreatedBy = httpContextAccessor?.HttpContext?.User.Identity?.Name ?? "Admin";
                    break;
                case EntityState.Modified:
                    Entry(entity).Property(nameof(IEntity.CreatedOn)).IsModified = false;
                    Entry(entity).Property(nameof(IEntity.CreatedBy)).IsModified = false;
                    break;
                case EntityState.Deleted:
                    entity.IsDeleted = true;
                    entityEntry.State = EntityState.Modified;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = httpContextAccessor?.HttpContext?.User.Identity?.Name ?? "Admin";
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<StudentInfo> StudentInfo { get; set; }
    public DbSet<TeacherInfo> TeacherInfo { get; set; }
    public DbSet<Activity> Activities { get; set; }
}