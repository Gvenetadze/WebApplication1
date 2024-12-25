using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

[Index(nameof(Name))]
public class Library
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }
}
