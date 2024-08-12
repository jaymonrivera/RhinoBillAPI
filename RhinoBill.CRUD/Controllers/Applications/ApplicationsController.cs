using Microsoft.AspNetCore.Mvc;
using RhinoBill.CRUD.Controllers.Applications.Dtos;
using RhinoBill.CRUD.Services.Interfaces;

namespace RhinoBill.CRUD.Controllers.Applications;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationListDto>>> GetApplications()
    {
        var applications = await _applicationService.GetApplicationsAsync();
        return Ok(applications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationFormDto>> GetApplication(int id)
    {
        var application = await _applicationService.GetApplicationByIdAsync(id);
        return Ok(application);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateApplication(ApplicationFormDto newApplicationDto)
    {
        var id = await _applicationService.CreateApplicationAsync(newApplicationDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteApplication(int id)
    {
        await _applicationService.DeleteApplicationAsync(id);
        return Ok("Deleted");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateApplication(int id, ApplicationFormDto applicationDto)
    {
        var applicationId = await _applicationService.UpdateApplicationAsync(id, applicationDto);
        return Ok(applicationId);
    }
}
