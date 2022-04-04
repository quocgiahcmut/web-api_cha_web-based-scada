namespace Application.EventHandlers;

public class TagsValueUpdatedEventHandler : INotificationHandler<TagValuesUpdatedEvent>
{
    private readonly ITagRepository _tagRepository;
    private readonly ITagValueRepository _tagValueRepository;

    public TagsValueUpdatedEventHandler(ITagRepository tagRepository, ITagValueRepository tagValueRepository)
    {
        _tagRepository = tagRepository;
        _tagValueRepository = tagValueRepository;
    }

    public async Task Handle(TagValuesUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.FindByTagName(notification.TagName);

        switch (tag.DataType)
        {
            case EDataType.Boolean:
                {
                    await _tagValueRepository.UpdateTag(tag.Id, Convert.ToBoolean(notification.Value));
                }
                break;

            case EDataType.Integer:
                {
                    await _tagValueRepository.UpdateTag(tag.Id, Convert.ToInt32(notification.Value));
                }
                break;

            case EDataType.Double:
                {
                    await _tagValueRepository.UpdateTag(tag.Id, Convert.ToDouble(notification.Value));
                }
                break;
        }
    }
}
