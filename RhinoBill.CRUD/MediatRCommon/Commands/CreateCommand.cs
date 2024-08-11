using MediatR;

namespace RhinoBill.CRUD.Common.Command;

public class CreateCommand<TEntity, TDto> : IRequest<int>
{
    public TDto Dto { get; set; }

    public CreateCommand(TDto dto)
    {
        Dto = dto;
    }
}
