namespace Application.Commands.Tags;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, bool>
{
    private readonly ITagRepository _tagRepository;

    public CreateTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = new Tag(request.TagId, request.TagName, request.DeviceId, request.EonNodeId, request.DataType);

        await _tagRepository.Add(tag);

        return await _tagRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
