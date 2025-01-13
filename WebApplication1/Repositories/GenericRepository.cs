using WebApplication1.DbContexts;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class GenericRepository<T>(LibraryDbContext context) : IGenericRepository<T> where T : class
{
    private LibraryDbContext _context { get; set; } = context;

    public IQueryable<T> GetLibraries()
    {
        return _context.Set<T>().AsQueryable();
    }

    public T? GetLibraryById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void AddLibrary(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void DeleteLibrary(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
