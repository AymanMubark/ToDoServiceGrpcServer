using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ToDoService.Data;
using ToDoService.Mapper;
using ToDoService.Repositories;
using ToDoService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("MissionDB");
});
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddAutoMapper(typeof(ToDoProfile));
// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<MissionService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
