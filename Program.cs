using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MnemosyneAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MemoriesDbContext>(options =>
    options.UseSqlite("Data Source=memories.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1"
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

app.Run();
