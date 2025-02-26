using Microsoft.EntityFrameworkCore;
using MnemosyneAPI.Context;
using MnemosyneAPI.Model;

namespace MnemosyneAPI.Endpoints
{
    public static class MemoriesEndpoints
    {
        public static void MapMemoriesEndpoints(this WebApplication app)
        {
            app.MapGet("/memories", async (MemoriesDbContext db) =>
            {
                return await db.Memories.ToListAsync();
            });

            app.MapGet("/memories/{id}", async (int id, MemoriesDbContext db) =>
            {
                return await db.Memories.FindAsync(id) is Memory memory
                    ? Results.Ok(memory)
                    : Results.NotFound();
            });

            app.MapPost("/memories", async (Memory memory, MemoriesDbContext db) =>
            {
                if (memory != null)
                {
                    db.Memories.Add(memory);
                    await db.SaveChangesAsync();

                    return Results.Created($"/memories/{memory.id}", memory);
                }
                return Results.BadRequest("Requisição inválida.");
            })
                .Produces<Memory>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/memories/{id}", async(int id, MemoriesDbContext db) =>
            {
                var memoriaEncontrada = await db.Memories.FindAsync(id);

                if (memoriaEncontrada is null) return Results.NotFound();

                db.Memories.Remove(memoriaEncontrada);
                await db.SaveChangesAsync();
                return Results.Ok(memoriaEncontrada);
            })
                .Produces<Memory>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            app.MapPut("memories/{id}", async(int id, Memory memory, MemoriesDbContext db) =>
            {
                var memoriaEncontrada = await db.Memories.FindAsync(id);
                if (memoriaEncontrada is null) return Results.NotFound();

                memoriaEncontrada.Title = memory.Title;
                memoriaEncontrada.Description = memory.Description;
                memoriaEncontrada.Date = memory.Date;
                memoriaEncontrada.Images = memory.Images;

                await db.SaveChangesAsync();
                return Results.NoContent();
            })
                .Produces<Memory>(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
        }
    }
}
