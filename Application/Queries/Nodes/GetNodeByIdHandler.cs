namespace Application.Queries.Nodes;

public class GetNodeByIdHandler : IRequestHandler<GetNodeById, EonNode>
{
    private readonly IEonNodeRepository _eonNodeRepository;

    public GetNodeByIdHandler(IEonNodeRepository eonNodeRepository)
    {
        _eonNodeRepository = eonNodeRepository;
    }

    public async Task<EonNode> Handle(GetNodeById request, CancellationToken cancellationToken)
    {
        var node = await _eonNodeRepository.FindById(request.NodeId);

        return node;
    }
}
