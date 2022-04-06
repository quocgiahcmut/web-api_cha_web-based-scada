namespace Application.Commands.Tags;

public class DeleteTagCommand : IRequest<bool>
{
    public string TagName { get; private set; }

    public DeleteTagCommand(string tagName)
    {
        TagName = tagName;
    }
}
