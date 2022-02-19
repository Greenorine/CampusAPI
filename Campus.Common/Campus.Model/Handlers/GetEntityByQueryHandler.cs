using System.Linq.Expressions;
using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Campus.Model.Handlers;

public record GetEntityByQuery<T>(Expression<Func<T, bool>> Query) : IRequest<T> where T : class, IBaseEntity;

public class GetEntityByQueryHandler<T> : IRequestHandler<GetEntityByQuery<T>, T> where T : class, IBaseEntity
{
    private AppDbContext context;
    
    public GetEntityByQueryHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<T> Handle(GetEntityByQuery<T> request, CancellationToken cancellationToken)
    {
        return await context.Set<T>().AsNoTracking().Where(request.Query).FirstOrDefaultAsync(cancellationToken);
    }
}
