using System.ComponentModel.DataAnnotations.Schema;

namespace RhinoBill.CRUD.Models;

public record Student
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; } = DateTime.MinValue;
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }

    [NotMapped]
    public string FullName { get { return $"{FirstName} {LastName}"; } }

    public ICollection<Application>? Applications { get; set; }
}
