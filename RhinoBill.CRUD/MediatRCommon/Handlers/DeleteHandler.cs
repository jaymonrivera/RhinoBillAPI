using MediatR;
using RhinoBill.CRUD.Common.Command;

namespace RhinoBill.CRUD.MediatRCommon.Handlers;

public class DeleteHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>>
    where TEntity : class
{
    private readonly RhinoBillDbContext _context;

    public DeleteHandler(RhinoBillDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>().FindAsync(request.Id);
        if (entity == null)
        {
            throw new ArgumentException($"{nameof(TEntity)}with Id: {request.Id} cannot be found");
        }

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

}

