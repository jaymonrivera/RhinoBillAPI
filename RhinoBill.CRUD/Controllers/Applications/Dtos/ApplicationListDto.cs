namespace RhinoBill.CRUD.Controllers.Applications.Dtos;

public record ApplicationListDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime ApplicationDate { get; set; }

}
