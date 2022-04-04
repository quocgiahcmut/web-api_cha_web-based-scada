namespace Application.Wrappers;

public class DeviceQueryResult
{
    public string DeviceId { get; set; }
    public bool Connected { get; set; }
    public List<TagQueryResult> TagQueryResults { get; set; }
}
