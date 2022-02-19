namespace Campus.API.Utils;

public static class BuilderExtensions
{
    public static void RegisterGenericHandlers(this WebApplicationBuilder builder)
    {
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
        {
            builder.RegisterGeneric(typeof(DeleteEntityByIdHandler<>)).As(typeof(IRequestHandler<,>));
            builder.RegisterGeneric(typeof(GetAllEntitiesHandler<>)).As(typeof(IRequestHandler<,>));
            builder.RegisterGeneric(typeof(GetEntityByIdHandler<>)).As(typeof(IRequestHandler<,>));
            builder.RegisterGeneric(typeof(GetEntityByQueryHandler<>)).As(typeof(IRequestHandler<,>));
            builder.RegisterGeneric(typeof(UpdateEntityHandler<>)).As(typeof(IRequestHandler<,>));
            builder.RegisterGeneric(typeof(UpsertEntityHandler<>)).As(typeof(IRequestHandler<,>));
        }));
    }
}