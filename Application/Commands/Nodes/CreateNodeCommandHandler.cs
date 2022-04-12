namespace Application.Commands.Nodes;

public class CreateNodeCommandHandler : IRequestHandler<CreateNodeCommand, bool>
{
    private readonly IEonNodeRepository _repository;

    public CreateNodeCommandHandler(IEonNodeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
    {
        var eonNode = new EonNode(request.NodeId, request.Connected);

        await _repository.Add(eonNode);

        return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
