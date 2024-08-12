using MediatR;

namespace RhinoBill.CRUD.Common.Command;

public class UpdateCommand<TEntity, TDto> : IRequest <int>
{
    public int Id { get; set; }
    public TDto Dto { get; set; }

    public UpdateCommand(int id, TDto dto)
    {
        Id = id;
        Dto = dto;
    }
}