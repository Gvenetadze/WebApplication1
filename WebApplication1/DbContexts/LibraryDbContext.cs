using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DbContexts
{
    public class LibraryDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Library> Libraries { get; set; }
    }
}
