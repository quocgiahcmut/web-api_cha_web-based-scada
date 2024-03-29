﻿namespace Application.Queries;

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

        DeviceQueryResult deviceQueryResult = new DeviceQueryResult
        {
            DeviceId = device.Id,
            Connected = device.Connected,
            TagQueryResults = new List<TagQueryResult>()
        };

        foreach (string tagName in request.TagNames)
        {
            var tag = await _tagRepository.FindByTagName(tagName);

            var tagValue = new Object();
            switch (tag.DataType)
            {
                case EDataType.Boolean:
                    tagValue = await _tagValueRepository.GetLatestValue("tableBool", tag.Id);
                    break;
                case EDataType.Integer:
                    tagValue = await _tagValueRepository.GetLatestValue("tableInt", tag.Id);
                    break;
                case EDataType.Double:
                    tagValue = await _tagValueRepository.GetLatestValue("tableDouble", tag.Id);
                    break;
            }

            var tagQueryResult = new TagQueryResult
            {
                TagName = tag.Name,
                Value = tagValue
            };

            deviceQueryResult.TagQueryResults.Add(tagQueryResult);
        }

        return deviceQueryResult;
    }
}
