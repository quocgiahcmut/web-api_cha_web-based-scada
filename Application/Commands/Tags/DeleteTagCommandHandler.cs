namespace Application.Commands.Tags;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, bool>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.FindByTagName(request.TagName);

        _tagRepository.Delete(tag);

        return await _tagRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
