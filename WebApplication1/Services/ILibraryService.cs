using WebApplication1.Models.LibraryModels;

namespace WebApplication1.Services;
public interface ILibraryService
{
    IEnumerable<LibraryViewModel> GetAll();
    LibraryViewModel GetById(int id);
    void Add(LibraryAddModel model);
    void Update(LibraryUpdateModel model, int id);
    void Delete(int id);
}
