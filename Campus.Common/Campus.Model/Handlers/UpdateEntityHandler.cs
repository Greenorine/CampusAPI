using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;

namespace Campus.Model.Handlers;

public record UpdateEntity<T>(T Entity) : IRequest<bool> where T : class, IBaseEntity;

public class UpdateEntityHandler<T> : IRequestHandler<UpdateEntity<T>, bool> where T : class, IBaseEntity
{
    private AppDbContext context;
    
    public UpdateEntityHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<bool> Handle(UpdateEntity<T> request, CancellationToken cancellationToken)
    {
        var find = await context.FindAsync<T>(request.Entity.Id);
        if (find == null) return false;
        context.Entry(find).CurrentValues.SetValues(request.Entity);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
