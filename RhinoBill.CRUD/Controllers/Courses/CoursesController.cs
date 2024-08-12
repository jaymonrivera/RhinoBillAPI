using Microsoft.AspNetCore.Mvc;
using RhinoBill.CRUD.Controllers.Courses.Dtos;
using RhinoBill.CRUD.Services.Interfaces;

namespace RhinoBill.CRUD.Controllers.Courses;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CourseListDto>>> GetCourses()
    {
        var courses = await _courseService.GetCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseFormDto>> GetCourse(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCourse(CourseFormDto newCourseDto)
    {
        var id = await _courseService.CreateCourseAsync(newCourseDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteCourse(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return Ok("Deleted");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateCourse(int id, CourseFormDto courseDto)
    {
        var courseId = await _courseService.UpdateCourseAsync(id, courseDto);
        return Ok(courseId);
    }
}

