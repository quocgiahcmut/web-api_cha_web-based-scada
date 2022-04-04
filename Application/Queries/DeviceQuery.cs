namespace Application.Queries;

public class DeviceQuery : IRequest<DeviceQueryResult>
{
    public string DeviceId { get; set; }
    public List<string> TagNames { get; set; }
}
