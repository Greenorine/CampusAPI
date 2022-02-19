using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;

namespace Campus.Model.Handlers;

public record DeleteEntityById<T>(Guid Id) : IRequest<T>, IRequest<bool> where T : class, IBaseEntity;

public class DeleteEntityByIdHandler<T> : IRequestHandler<DeleteEntityById<T>, bool> where T : class, IBaseEntity
{
    private AppDbContext context;
    
    public DeleteEntityByIdHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<bool> Handle(DeleteEntityById<T> request, CancellationToken cancellationToken)
    {
        var find = context.Find<T>(request.Id);
        if (find == null) return false;
        var entry = context.Entry(find);
        if (entry.Entity is IHistoricalEntity)
            entry.CurrentValues[nameof(IHistoricalEntity.IsDeleted)] = false;
        else
            context.Remove(find);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
