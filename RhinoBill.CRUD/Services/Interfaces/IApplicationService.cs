using RhinoBill.CRUD.Controllers.Applications.Dtos;

namespace RhinoBill.CRUD.Services.Interfaces;

public interface IApplicationService
{
    Task<IList<ApplicationListDto>> GetApplicationsAsync();
    Task<ApplicationFormDto> GetApplicationByIdAsync(int id);
    Task<int> CreateApplicationAsync(ApplicationFormDto applicationDto);
    Task<int> UpdateApplicationAsync(int id, ApplicationFormDto applicationDto);
    Task DeleteApplicationAsync(int id);
}
