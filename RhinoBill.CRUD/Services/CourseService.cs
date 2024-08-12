using MediatR;
using RhinoBill.CRUD.Common.Command;
using RhinoBill.CRUD.Controllers.Courses.Dtos;
using RhinoBill.CRUD.MediatRCommon.Commands;
using RhinoBill.CRUD.Models;
using RhinoBill.CRUD.Services.Interfaces;

namespace RhinoBill.CRUD.Services;

public class CourseService : ICourseService
{
    private readonly IMediator _mediator;

    public CourseService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IList<CourseListDto>> GetCoursesAsync()
    {
        var query = new GetAllCommand<Course, CourseListDto>();
        var courses = await _mediator.Send(query);
        return courses.ToList();
    }

    public async Task<CourseFormDto> GetCourseByIdAsync(int id)
    {
        var query = new GetByIdCommand<Course, CourseFormDto>(id);
        return await _mediator.Send(query);
    }

    public async Task<int> CreateCourseAsync(CourseFormDto courseDto)
    {
        var command = new CreateCommand<Course, CourseFormDto>(courseDto);
        return await _mediator.Send(command);
    }

    public async Task<int> UpdateCourseAsync(int id, CourseFormDto courseDto)
    {
        var command = new UpdateCommand<Course, CourseFormDto>(id, courseDto);
        return await _mediator.Send(command);
    }

    public async Task DeleteCourseAsync(int id)
    {
        var command = new DeleteCommand<Course>(id);
        await _mediator.Send(command);
    }
}

