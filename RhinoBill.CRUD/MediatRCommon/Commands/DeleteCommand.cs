using MediatR;

namespace RhinoBill.CRUD.Common.Command;

public class DeleteCommand<TEntity> : IRequest
{
    public int Id { get; set; }
    public DeleteCommand(int id)
    {
        Id = id;
    }
}
