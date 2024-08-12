namespace RhinoBill.CRUD.Controllers.Applications.Dtos;

public record ApplicationFormDto
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime ApplicationDate { get; set; }

}
