namespace RhinoBill.CRUD.Controllers.Applications.Dtos;

public record ApplicationFormDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string ApplicationDate { get; set; }

}
