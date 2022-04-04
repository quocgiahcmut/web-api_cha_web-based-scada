namespace Domain.Models;
public class EonNode
{
    public string Id { get; set; }
    public bool Connected { get; set; }
    public List<Device> Devices { get; set; }

    public EonNode(string id, bool connected)
    {
        Id = id;
        Connected = connected;
        Devices = new List<Device>();
    }
}
