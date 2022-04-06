namespace Application.Commands.Nodes;

public class DeleteNodeCommandHandler : IRequestHandler<DeleteNodeCommand, bool>
{
    private readonly IEonNodeRepository _eonNodeRepository;

    public DeleteNodeCommandHandler(IEonNodeRepository eonNodeRepository)
    {
        _eonNodeRepository = eonNodeRepository;
    }

    public async Task<bool> Handle(DeleteNodeCommand request, CancellationToken cancellationToken)
    {
        var node = await _eonNodeRepository.FindById(request.EonNodeId);

        _eonNodeRepository.Delete(node);

        return await _eonNodeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
