using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;

namespace Campus.Model.Handlers;

public record UpsertEntity<T>(T Entity) : IRequest<T>, IRequest<Guid> where T : class, IBaseEntity;

public class UpsertEntityHandler<T> : IRequestHandler<UpsertEntity<T>, Guid> where T : class, IBaseEntity
{
    private AppDbContext context;
    
    public UpsertEntityHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<Guid> Handle(UpsertEntity<T> request, CancellationToken cancellationToken)
    {
        var id = (await context.AddAsync(request.Entity, cancellationToken)).Entity.Id;
        await context.SaveChangesAsync(cancellationToken);
        return id;
    }
}
