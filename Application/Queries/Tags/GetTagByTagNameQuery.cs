namespace Application.Queries.Tags;

public class GetTagByTagNameQuery : IRequest<Tag>
{
    public string TagName { get; set; }

    public GetTagByTagNameQuery(string tagName)
    {
        TagName = tagName;
    }
}
