namespace Application.Commands.Nodes;

public class CreateNodeCommand : IRequest<bool>
{
    public string Id { get; set; }
    public bool Connected { get; set; }

    public CreateNodeCommand(string id, bool connected)
    {
        Id = id;
        Connected = connected;
    }
}
