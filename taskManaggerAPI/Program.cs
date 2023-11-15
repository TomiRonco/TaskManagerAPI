using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using taskManaggerAPI.Data.Implementations;
using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;
using taskManaggerAPI.Services.Implementations;
using taskManaggerAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<taskManaggerContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["DB:ConnectionString"]));

#region Repositories
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

#region Services
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
