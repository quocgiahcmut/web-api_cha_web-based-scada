namespace Infrastructure.Persistence.Repositories;

public class DeviceRepository : BaseRepository, IDeviceRepository
{
    public DeviceRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task Add(Device device)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Device device)
    {
        throw new NotImplementedException();
    }

    public Task<Device> FindById(string deviceId)
    {
        throw new NotImplementedException();
    }

    public Task Update(Device device)
    {
        throw new NotImplementedException();
    }
}
