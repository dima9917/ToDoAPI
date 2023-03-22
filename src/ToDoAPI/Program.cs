using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDb"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
    {
        var items = await context.ToDoItems.ToListAsync();
        return Results.Ok(items);
    }
);

app.MapGet("api/todo/{id}", async (AppDbContext context, int id) =>
    {
        var items = await context.ToDoItems.FirstOrDefaultAsync(x=>x.Id==id);
        return Results.Ok(items);
    }
);

app.MapPost("api/todo", async (AppDbContext context, ToDoItem item) =>
    {
        await context.ToDoItems.AddAsync(item);
        await context.SaveChangesAsync();
        return Results.Created("api/todo/" + item.Id ,item);
    }
);
app.Run();
