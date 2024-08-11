using MediatR;

namespace RhinoBill.CRUD.MediatRCommon.Commands;

public class GetAllCommand<TEntity, TDto> : IRequest<IEnumerable<TDto>>
{
}
