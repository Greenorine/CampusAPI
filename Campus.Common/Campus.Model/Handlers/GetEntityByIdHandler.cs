using Campus.Db;
using Campus.Db.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Campus.Model.Handlers;

public record GetEntityById<T>(Guid Id) : IRequest<T> where T : class, IBaseEntity;

public class GetEntityByIdHandler<T> : IRequestHandler<GetEntityById<T>, T> where T : class, IBaseEntity
{
    private AppDbContext context;

    public GetEntityByIdHandler(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<T> Handle(GetEntityById<T> request, CancellationToken cancellationToken)
    {
        return await context.Set<T>()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}