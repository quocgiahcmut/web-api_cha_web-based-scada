namespace Application.Queries.Nodes;

public class GetNodeByIdQueryHandler : IRequestHandler<GetNodeByIdQuery, EonNode>
{
    private readonly IEonNodeRepository _eonNodeRepository;

    public GetNodeByIdQueryHandler(IEonNodeRepository eonNodeRepository)
    {
        _eonNodeRepository = eonNodeRepository;
    }

    public async Task<EonNode> Handle(GetNodeByIdQuery request, CancellationToken cancellationToken)
    {
        var node = await _eonNodeRepository.FindById(request.NodeId);

        return node;
    }
}
