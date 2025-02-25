using Microsoft.EntityFrameworkCore;
using MnemosyneAPI.Model;

namespace MnemosyneAPI.Context
{
    public class MemoriesDbContext : DbContext
    {
        public MemoriesDbContext(DbContextOptions<MemoriesDbContext> options) : base(options)
        {
        }
        public DbSet<Memory> Memories => Set<Memory>();
    }
}
