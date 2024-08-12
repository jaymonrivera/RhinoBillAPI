using AutoMapper;
using MediatR;
using RhinoBill.CRUD.Common.Command;

namespace RhinoBill.CRUD.MediatRCommon.Handlers;

public class CreateHandler<TEntity, TDto> : IRequestHandler<CreateCommand<TEntity, TDto>, int>
    where TEntity : class
{
    private readonly RhinoBillDbContext _context;
    private readonly IMapper _mapper;

    public CreateHandler(RhinoBillDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCommand<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(request.Dto);
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return (int)typeof(TEntity).GetProperty("Id")!.GetValue(entity)!;
    }
}