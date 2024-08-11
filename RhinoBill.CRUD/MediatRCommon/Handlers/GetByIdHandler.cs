using AutoMapper;
using MediatR;
using RhinoBill.CRUD.Common.Command;

namespace RhinoBill.CRUD.MediatRCommon.Handlers;

public class GetByIdHandler<TEntity, TDto> : IRequestHandler<GetByIdCommand<TEntity, TDto>, TDto>
    where TEntity : class
{
    private readonly RhinoBillDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdHandler(RhinoBillDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TDto> Handle(GetByIdCommand<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>().FindAsync(request.Id);
        if (entity == null)
        {
            throw new ArgumentException($"{nameof(TEntity)}with Id: {request.Id} cannot be found");
        }
        return _mapper.Map<TDto>(entity);
    }
}
