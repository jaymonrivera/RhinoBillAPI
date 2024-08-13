namespace RhinoBill.CRUD.Controllers.Applications.Dtos;

public record ApplicationListDto
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string Course { get; set; }
    public DateTime ApplicationDate { get; set; }

}
