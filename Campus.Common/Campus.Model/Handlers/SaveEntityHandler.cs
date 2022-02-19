using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Campus.Model.Handlers;

public record SaveEntity<T>(T Entity) : IRequest<Guid?> where T : class, IBaseEntity;

public class SaveEntityHandler<T> : IRequestHandler<SaveEntity<T>, Guid?> where T : class, IBaseEntity
{
    private AppDbContext context;

    public SaveEntityHandler(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Guid?> Handle(SaveEntity<T> request, CancellationToken cancellationToken)
    {
        var id = request.Entity.Id;
        if (id.HasValue)
        {
            context.Attach(request.Entity);
            context.Entry(request.Entity).State = EntityState.Modified;
        }
        else
            id = (await context.Set<T>().AddAsync(request.Entity, cancellationToken)).Entity.Id;

        await context.SaveChangesAsync(cancellationToken);
        return id;
    }
}