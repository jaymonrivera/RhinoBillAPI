using RhinoBill.CRUD.Controllers.Students.Dtos;

namespace RhinoBill.CRUD.Services.Interfaces;

public interface IStudentService
{
    Task<IList<StudentListDto>> GetStudentsAsync();
    Task<StudentFormDto> GetStudentByIdAsync(int id);
    Task<int> CreateStudentAsync(StudentFormDto studentDto);
    Task<int> UpdateStudentAsync(int id, StudentFormDto studentDto);
    Task DeleteStudentAsync(int id);
}