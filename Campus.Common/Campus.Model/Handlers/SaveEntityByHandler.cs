using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;

namespace Campus.Model.Handlers;

public record SaveEntityById<T>(Guid Id) : IRequest<T> where T : class, IBaseEntity;

public class SaveEntityByHandler<T> : IRequestHandler<GetEntityById<T>, T> where T : class, IBaseEntity
{
    private AppDbContext context;
    
    public SaveEntityByHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<T> Handle(GetEntityById<T> request, CancellationToken cancellationToken)
    {
        return await context.FindAsync<T>(request.Id);
    }
}
