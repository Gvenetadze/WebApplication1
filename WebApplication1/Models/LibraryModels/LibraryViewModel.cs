using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.LibraryModels;

public class LibraryViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }
}
