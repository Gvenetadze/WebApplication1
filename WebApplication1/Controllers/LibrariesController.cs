using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContexts;
using WebApplication1.Entities;
using WebApplication1.Models.LibraryModels;
using WebApplication1.Utils.Exceptions;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibrariesController(LibraryDbContext context) : ControllerBase
{
    private readonly LibraryDbContext _context = context;

    [HttpGet]
    [Route("GetLibraries")]
    public IEnumerable<LibraryViewModel> GetLibraries()
    {
        var libraries = _context
            .Libraries
            .AsNoTracking()
            .Select(l => new LibraryViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
                Email = l.Email,
            });
        
        return libraries;
    }

    [HttpGet]
    [Route("GetLibraryById/{id:int}")]
    public LibraryViewModel GetLibraryById(int id)
    {
        var library = _context
            .Libraries
            .AsNoTracking()
            .Select(l => new LibraryViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
                Email = l.Email,
            })
            .FirstOrDefault(l => l.Id == id);

        return library is null ? throw new NotFoundException() : library;
    }

    [HttpPost]
    [Route("AddLibrary")]
    public LibraryViewModel AddLibrary([FromBody] LibraryAddModel model)
    {
        var library = new Library
        {
            Name = model.Name,
            Email = model.Email,
            Address = model.Address
        };

        _context.Libraries.Add(library);
        _context.SaveChanges();

        return new LibraryViewModel
        {
            Id = library.Id,
            Name = library.Name,
            Address = library.Address,
            Email = library.Email
        };
    }

    [HttpPut]
    [Route("UpdateLibrary/{id:int}")]
    public LibraryViewModel UpdateLibrary([FromBody] LibraryUpdateModel model, [FromRoute] int id)
    {
        var library = _context
            .Libraries
            .FirstOrDefault(l => l.Id == id) ?? throw new NotFoundException();

        library.Name = model.Name;
        library.Email = model.Email;
        library.Address = model.Address;

        _context.SaveChanges();

        return new LibraryViewModel
        {
            Id= library.Id,
            Name = library.Name,
            Address = library.Address,
            Email = library.Email
        };
    }

    [HttpDelete]
    [Route("DeleteLibrary")]
    public void DeleteLibrary(int id)
    {
        var library = _context
            .Libraries
            .FirstOrDefault(l => l.Id == id) ?? throw new NotFoundException();

        _context.Libraries.Remove(library);
        _context.SaveChanges();
    }

    [HttpPatch]
    [Route("UpdateLibrary/{id:int}")]
    public LibraryViewModel UpdateLibrary([FromRoute] int id, [FromBody] LibraryPatchModel model)
    {
        var library = _context
            .Libraries
            .FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException();

        if (model.Name != null)
        {
            library.Name = model.Name;
        }

        if (model.Address != null)
        {
            library.Address = model.Address;
        }

        if (model.Email != null)
        {
            library.Email = model.Email;
        }

        _context.SaveChanges();

        return new LibraryViewModel
        {
            Id = library.Id,
            Name = library.Name,
            Address = library.Address,
            Email = library.Email
        };

    }
}
