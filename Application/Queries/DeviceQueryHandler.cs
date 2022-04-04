namespace Application.Queries;

public class DeviceQueryHandler : IRequestHandler<DeviceQuery, DeviceQueryResult>
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly ITagRepository _tagRepository;
    private readonly ITagValueRepository _tagValueRepository;

    public DeviceQueryHandler(IDeviceRepository deviceRepository, ITagRepository tagRepository, ITagValueRepository tagValueRepository)
    {
        _deviceRepository = deviceRepository;
        _tagRepository = tagRepository;
        _tagValueRepository = tagValueRepository;
    }

    public async Task<DeviceQueryResult> Handle(DeviceQuery request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.FindById(request.DeviceId);

        DeviceQueryResult deviceQueryResult = new DeviceQueryResult();

        deviceQueryResult.DeviceId = device.Id;
        deviceQueryResult.Connected = device.Connected;

        foreach (string tagName in request.TagNames)
        {
            var tag = await _tagRepository.FindByTagName(tagName);
            var tagValue = _tagValueRepository.GetLatestValue(tag.Id);

            TagQueryResult tagQueryResult = new TagQueryResult()
            {
                TagName = tag.Name,
                Value = tagValue
            };

            deviceQueryResult.TagQueryResults.Add(tagQueryResult);
        }

        return deviceQueryResult;
    }
}
