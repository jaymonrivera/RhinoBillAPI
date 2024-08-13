using FluentValidation;

namespace RhinoBill.CRUD.Controllers.Courses.Dtos;

public record CourseFormDto
{
    public int Id { get; set; }
    public string Code { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public int Credits { get; init; }
}


public class CourseFormValidator : AbstractValidator<CourseFormDto>
{
    public CourseFormValidator()
    {
        RuleFor(x => x.Code).NotEmpty().Length(5, 10).Matches(@"^[a-zA-Z0-9]+$");
        RuleFor(x => x.Title).NotEmpty().Length(2, 30);
        RuleFor(x => x.Credits).GreaterThan(0);
    }
}