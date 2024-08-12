using MediatR;
using RhinoBill.CRUD.Common.Command;
using RhinoBill.CRUD.Controllers.Applications.Dtos;
using RhinoBill.CRUD.MediatRCommon.Commands;
using RhinoBill.CRUD.Models;
using RhinoBill.CRUD.Services.Interfaces;

namespace RhinoBill.CRUD.Services;

public class ApplicationService : IApplicationService
{
    private readonly IMediator _mediator;

    public ApplicationService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IList<ApplicationListDto>> GetApplicationsAsync()
    {
        var query = new GetAllCommand<Application, ApplicationListDto>();
        var applications = await _mediator.Send(query);
        return applications.ToList();
    }

    public async Task<ApplicationFormDto> GetApplicationByIdAsync(int id)
    {
        var query = new GetByIdCommand<Application, ApplicationFormDto>(id);
        return await _mediator.Send(query);
    }

    public async Task<int> CreateApplicationAsync(ApplicationFormDto applicationDto)
    {
        var command = new CreateCommand<Application, ApplicationFormDto>(applicationDto);
        return await _mediator.Send(command);
    }

    public async Task<int> UpdateApplicationAsync(int id, ApplicationFormDto applicationDto)
    {
        var command = new UpdateCommand<Application, ApplicationFormDto>(id, applicationDto);
        return await _mediator.Send(command);
    }

    public async Task DeleteApplicationAsync(int id)
    {
        var command = new DeleteCommand<Application>(id);
        await _mediator.Send(command);
    }
}
