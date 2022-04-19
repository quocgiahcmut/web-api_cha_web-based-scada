namespace Application.Queries.Tags;

public class GetTagByTagNameQueryHandler : IRequestHandler<GetTagByTagNameQuery, Tag>
{
    private readonly ITagRepository _tagRepository;

    public GetTagByTagNameQueryHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Tag> Handle(GetTagByTagNameQuery request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.FindByTagName(request.TagName);

        return tag;
    }
}
