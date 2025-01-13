using WebApplication1.Entities;
using WebApplication1.Models.LibraryModels;
using WebApplication1.Repositories;
using WebApplication1.Utils.Exceptions;

namespace WebApplication1.Services;
public class LibraryService(ILibraryRepository libraryRepository) : ILibraryService
{
    private readonly ILibraryRepository _libraryRepository = libraryRepository;

    public IEnumerable<LibraryViewModel> GetAll()
    {
        var libraries = _libraryRepository
            .GetLibraries()
            .Select(l => new LibraryViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
                Email = l.Email,
            });
        return libraries;
    }

    public LibraryViewModel GetById(int id)
    {
        var library = _libraryRepository.GetLibraryById(id) ?? throw new NotFoundException();

        var libraryViewModel = new LibraryViewModel
        {
            Id = library.Id,
            Name = library.Name,
            Address = library.Address,
            Email = library.Email,
        };

        return libraryViewModel;
    }

    public void Add(LibraryAddModel model)
    {
        var library = new Library
        {
            Name = model.Name,
            Email = model.Email,
            Address = model.Address
        };

        _libraryRepository.AddLibrary(library);
        _libraryRepository.SaveChanges();
    }

    public void Update(LibraryUpdateModel model, int id)
    {
        var library = _libraryRepository.GetLibraryById(id) ?? throw new NotFoundException();

        library.Name = model.Name;
        library.Address = model.Address;
        library.Email = model.Email;

        _libraryRepository.SaveChanges();
    }

    public void Delete(int id)
    {
        var library = _libraryRepository.GetLibraryById(id) ?? throw new NotFoundException();

        _libraryRepository.DeleteLibrary(library);
        _libraryRepository.SaveChanges();
    }
}
