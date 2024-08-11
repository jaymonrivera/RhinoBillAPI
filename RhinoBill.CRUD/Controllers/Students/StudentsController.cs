using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhinoBill.CRUD.Common.Command;
using RhinoBill.CRUD.Controllers.Students.Dtos;
using RhinoBill.CRUD.MediatRCommon.Commands;
using RhinoBill.CRUD.Models;

namespace RhinoBill.CRUD.Controllers.Students;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var query = new GetAllCommand<Student, StudentDto>();
        var students = await _mediator.Send(query);

        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Student>>> GetStudents(int id)
    {
        var query = new GetByIdCommand<Student, StudentDto>(id);
        var students = await _mediator.Send(query);

        return Ok(students);
    }

    [HttpPost]   
    public async Task<ActionResult<int>> CreateStudent(StudentDto newStudentDto)
    {
        var createStudentCommand = new CreateCommand<Student, StudentDto>(newStudentDto);
        var id = await _mediator.Send(createStudentCommand);

        return Ok(id);
    }

    [HttpDelete]
    public async Task<ActionResult<int>> DeleteStudent(int id)
    {
        var deleteStudentCommand = new DeleteCommand<Student>(id);
        await _mediator.Send(deleteStudentCommand);

        return Ok("Deleted");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateStudent(int id, StudentDto studentDto)
    {
        var updateStudentCommand = new UpdateCommand<Student, StudentDto>(id, studentDto);
        var student = await _mediator.Send(updateStudentCommand);

        return Ok(student);
    }
}
