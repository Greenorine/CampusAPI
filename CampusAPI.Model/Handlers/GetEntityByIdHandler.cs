using CampusAPI.Db;
using CampusAPI.Db.Entities;
using CampusAPI.Model.Interfaces;
using MediatR;

namespace CampusAPI.Model.Handlers;

public record GetEntityById<T>(Guid Id) : IRequest<T> where T : class, IEntity;

public class GetEntityByIdHandler<T> : IRequestHandler<GetEntityById<T>, T> where T : class, IEntity
{
    private AppDbContext context;
    
    public GetEntityByIdHandler(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<T> Handle(GetEntityById<T> request, CancellationToken cancellationToken)
    {
        return await context.FindAsync<T>(request.Id);
    }
}
