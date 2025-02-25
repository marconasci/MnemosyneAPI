using Microsoft.EntityFrameworkCore;
using MnemosyneAPI.Context;
using MnemosyneAPI.Model;

namespace MnemosyneAPI.Endpoints
{
    public static class MemoriesEndpoints
    {
        public static void MapMemoriesEndpoints()
        {
            app.MapGet("/memories", async (MemoriesDbContext) =>
            {
                return await DbContext.Memories.ToListAsync();
            });
        }
    }
}
