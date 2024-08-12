using Microsoft.AspNetCore.Mvc;
using RhinoBill.CRUD.Controllers.Students.Dtos;
using RhinoBill.CRUD.Models;
using RhinoBill.CRUD.Services.Interfaces;

namespace RhinoBill.CRUD.Controllers.Students;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentListDto>>> GetStudents()
    {
        var students = await _studentService.GetStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentFormDto>> GetStudent(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]   
    public async Task<ActionResult<int>> CreateStudent(StudentFormDto newStudentDto)
    {
        var id = await _studentService.CreateStudentAsync(newStudentDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteStudent(int id)
    {
        await _studentService.DeleteStudentAsync(id);
        return Ok("Deleted");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateStudent(int id, StudentFormDto studentDto)
    {
        var studentId = await _studentService.UpdateStudentAsync(id, studentDto);
        return Ok(studentId);
    }
}
