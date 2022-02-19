using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Campus.Model.Handlers;

public record GetAllEntities<T> : IRequest<List<T>> where T : class, IBaseEntity;

public class GetAllEntitiesHandler<T> : IRequestHandler<GetAllEntities<T>, List<T>> where T : class, IBaseEntity
{
    private AppDbContext context;
    
    public GetAllEntitiesHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<List<T>> Handle(GetAllEntities<T> request, CancellationToken cancellationToken)
    {
        return await context.Set<T>().ToListAsync(cancellationToken);
    }
}
