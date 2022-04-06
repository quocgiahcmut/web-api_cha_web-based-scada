namespace Domain.Repositories;

public interface IDeviceRepository : IRepository
{
    Task Add(Device device);
    void Update(Device device);
    void Delete(Device device);
    Task<Device> FindById(string deviceId);
}
