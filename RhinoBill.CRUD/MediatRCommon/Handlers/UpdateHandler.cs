using AutoMapper;
using MediatR;
using RhinoBill.CRUD.Common.Command;

namespace RhinoBill.CRUD.MediatRCommon.Handlers;

public class UpdateHandler<TEntity, TDto> : IRequestHandler<UpdateCommand<TEntity, TDto>, int>
    where TEntity : class
{
    private readonly RhinoBillDbContext _context;
    private readonly IMapper _mapper;

    public UpdateHandler(RhinoBillDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(UpdateCommand<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>().FindAsync(request.Id);
        if (entity == null)
        {
            throw new Exception($"{typeof(TEntity).Name} with Id: {request.Id} cannot be found");
        }

        _mapper.Map(request.Dto, entity);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }


}