using Newtonsoft.Json;

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

    public async Task<NodeQueryResult> GetListTagsWithJson(string jsonNodeQuery)
    {
        var nodeQuery = JsonConvert.DeserializeObject<NodeQuery>(jsonNodeQuery);
        var result = await _mediator.Send(nodeQuery);

        return result;
    }
}
