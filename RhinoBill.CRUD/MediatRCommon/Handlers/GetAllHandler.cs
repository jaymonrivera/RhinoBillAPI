using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        var dtos = await _context.Set<TEntity>()
            .ProjectTo<TDto>(_mapper.ConfigurationProvider) 
            .ToListAsync(cancellationToken);

        return dtos;
    }
}
