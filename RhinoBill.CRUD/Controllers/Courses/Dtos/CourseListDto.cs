namespace RhinoBill.CRUD.Controllers.Courses.Dtos;

public record CourseListDto
{
    public int Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public int Credits { get; init; }
}
