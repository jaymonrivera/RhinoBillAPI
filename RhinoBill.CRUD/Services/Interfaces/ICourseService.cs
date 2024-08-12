using RhinoBill.CRUD.Controllers.Courses.Dtos;

namespace RhinoBill.CRUD.Services.Interfaces;

public interface ICourseService
{
    Task<IList<CourseListDto>> GetCoursesAsync();
    Task<CourseFormDto> GetCourseByIdAsync(int id);
    Task<int> CreateCourseAsync(CourseFormDto courseDto);
    Task<int> UpdateCourseAsync(int id, CourseFormDto courseDto);
    Task DeleteCourseAsync(int id);
}
