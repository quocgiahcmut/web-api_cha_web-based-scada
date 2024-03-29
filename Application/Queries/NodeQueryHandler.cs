﻿namespace Application.Queries;

public class NodeQueryHandler : IRequestHandler<NodeQuery, NodeQueryResult>
{
    private readonly IEonNodeRepository _nodeRepository;
    private readonly IDeviceRepository _deviceRepository;
    private readonly ITagRepository _tagRepository;
    private readonly ITagValueRepository _tagValueRepository;
    private readonly IMediator _mediator;

    public NodeQueryHandler(IEonNodeRepository nodeRepository, IDeviceRepository deviceRepository, ITagRepository tagRepository, ITagValueRepository tagValueRepository, IMediator mediator)
    {
        _nodeRepository = nodeRepository;
        _deviceRepository = deviceRepository;
        _tagRepository = tagRepository;
        _tagValueRepository = tagValueRepository;
        _mediator = mediator;
    }

    public async Task<NodeQueryResult> Handle(NodeQuery request, CancellationToken cancellationToken)
    {
        var eonNode = await _nodeRepository.FindById(request.EonNodeId);

        NodeQueryResult nodeQueryResult = new NodeQueryResult
        {
            EonNodeId = eonNode.Id,
            DeviceQueryResults = new List<DeviceQueryResult>()
        };

        foreach (DeviceQuery deviceQuery in request.DeviceQueries)
        {
            var deviceQueryResult = await _mediator.Send(deviceQuery);
            
            nodeQueryResult.DeviceQueryResults.Add(deviceQueryResult);
        }

        return nodeQueryResult;
    }
}
