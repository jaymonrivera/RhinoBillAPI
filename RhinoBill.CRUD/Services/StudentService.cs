using MediatR;
using RhinoBill.CRUD.Common.Command;
using RhinoBill.CRUD.Controllers.Students.Dtos;
using RhinoBill.CRUD.MediatRCommon.Commands;
using RhinoBill.CRUD.Models;
using RhinoBill.CRUD.Services.Interfaces;

namespace RhinoBill.CRUD.Services;

public class StudentService : IStudentService
{
    private readonly IMediator _mediator;

    public StudentService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IList<StudentListDto>> GetStudentsAsync()
    {
        var query = new GetAllCommand<Student, StudentListDto>();
        var students = await _mediator.Send(query);
        return students.ToList();
    }

    public async Task<StudentFormDto> GetStudentByIdAsync(int id)
    {
        var query = new GetByIdCommand<Student, StudentFormDto>(id);

        var student = await _mediator.Send(query);

        if (student == null)
        {
            throw new Exception($"Student with Id: {id} cannot be found");
        }
        return student;
    }

    public async Task<int> CreateStudentAsync(StudentFormDto studentDto)
    {
        var command = new CreateCommand<Student, StudentFormDto>(studentDto);
        return await _mediator.Send(command);
    }

    public async Task<int> UpdateStudentAsync(int id, StudentFormDto studentDto)
    {
        var command = new UpdateCommand<Student, StudentFormDto>(id, studentDto);
        return await _mediator.Send(command);
    }

    public async Task DeleteStudentAsync(int id)
    {
        var command = new DeleteCommand<Student>(id);
        await _mediator.Send(command);
    }
}
