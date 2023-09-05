using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Commands.CreateToDo;
using ToDo.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateToDoCommand).Assembly); });

builder.Services.AddDbContext<ToDoDbContext>(opt => opt.UseInMemoryDatabase("ToDoDB"));

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