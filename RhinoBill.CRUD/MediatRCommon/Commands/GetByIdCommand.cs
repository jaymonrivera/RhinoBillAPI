using MediatR;

namespace RhinoBill.CRUD.Common.Command;

public class GetByIdCommand<TEntity, TDto> : IRequest<TDto>
{
    public int Id { get; set; }

    public GetByIdCommand(int id)
    {
        Id = id;
    }
}
