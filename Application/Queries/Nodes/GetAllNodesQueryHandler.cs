namespace Application.Queries.Nodes;

public class GetAllNodesQueryHandler : IRequestHandler<GetAllNodesQuery, IEnumerable<EonNode>>
{
    private readonly IEonNodeRepository _eonNodeRepository;

    public GetAllNodesQueryHandler(IEonNodeRepository eonNodeRepository)
    {
        _eonNodeRepository = eonNodeRepository;
    }

    public Task<IEnumerable<EonNode>> Handle(GetAllNodesQuery request, CancellationToken cancellationToken)
    {
        var eonNodes = _eonNodeRepository.GetAllEonNode();

        return eonNodes;
    }
}
