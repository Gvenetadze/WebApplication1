using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContexts;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class LibraryRepository(LibraryDbContext context) : GenericRepository<Library>(context), ILibraryRepository
{
}
