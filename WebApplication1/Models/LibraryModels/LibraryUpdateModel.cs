using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.LibraryModels;

public class LibraryUpdateModel
{

    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }
}
