var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("kampus_connection") ?? string.Empty,
        b => b.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name));
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
{
    builder.RegisterGeneric(typeof(GetEntityByIdHandler<>)).As(typeof(IRequestHandler<,>));
}));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CampusModelDummy).GetTypeInfo().Assembly);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();