using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Data.Repositories;
using WebApi.Extensions.Middleware;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<StatusRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<StatusService>();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));



var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseMiddleware<DefaultApiKey>();

app.UseAuthorization();
app.MapControllers();
app.Run();
