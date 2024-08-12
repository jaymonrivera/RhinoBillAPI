using FluentValidation;

namespace RhinoBill.CRUD.Controllers.Students.Dtos;

public record StudentFormDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}

public class StudentFormValidator : AbstractValidator<StudentFormDto>
{
    public StudentFormValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().Length(2, 30).Matches(@"^[a-zA-Z\s]+$");
        RuleFor(x => x.LastName).NotEmpty().Length(2, 30).Matches(@"^[a-zA-Z\s]+$");
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}
