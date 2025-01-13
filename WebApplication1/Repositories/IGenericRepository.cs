namespace WebApplication1.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetLibraries();
    T? GetLibraryById(int id);
    void AddLibrary(T entity);
    void DeleteLibrary(T entity);
    void SaveChanges();
}
