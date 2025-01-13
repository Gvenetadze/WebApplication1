using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.LibraryModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibrariesController(ILibraryService libraryService) : ControllerBase
{
    private readonly ILibraryService _libraryService = libraryService;

    [HttpGet]
    public IEnumerable<LibraryViewModel> GetLibraries()
    {
        var libraries = _libraryService.GetAll();
        return libraries;
    }

    [HttpGet]
    [Route("{id:int}")]
    public LibraryViewModel GetLibraryById(int id)
    {   
        var library = _libraryService.GetById(id);
        return library;
    }

    [HttpPost]
    public void AddLibrary([FromBody] LibraryAddModel model)
    {
        _libraryService.Add(model);
    }

    [HttpPut]
    [Route("{id:int}")]
    public void UpdateLibrary([FromBody] LibraryUpdateModel model, [FromRoute] int id)
    {
        _libraryService.Update(model, id);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public void DeleteLibrary([FromRoute] int id)
    {
        _libraryService.Delete(id);
    }
}
