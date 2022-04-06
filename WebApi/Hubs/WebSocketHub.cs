namespace WebApi.Hubs;

public class WebSocketHub : Hub
{
    private readonly IMediator _mediator;
        
    public WebSocketHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<NodeQueryResult> GetListTags(NodeQuery nodeQuery)
    {
        var result = await _mediator.Send(nodeQuery);

        return result;
    }
}
