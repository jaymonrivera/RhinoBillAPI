using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RhinoBill.CRUD.MediatRCommon.Commands;

namespace RhinoBill.CRUD.MediatRCommon.Handlers;

public class GetAllHandler<TEntity, TDto> : IRequestHandler<GetAllCommand<TEntity, TDto>, IEnumerable<TDto>>
    where TEntity : class
{
    private readonly RhinoBillDbContext _context;
    private readonly IMapper _mapper;

    public GetAllHandler(RhinoBillDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> Handle(GetAllCommand<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entities = await _context.Set<TEntity>().ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }
}
