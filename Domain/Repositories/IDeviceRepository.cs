namespace Domain.Repositories;

public interface IDeviceRepository
{
    Task Add(Device device);
    Task Update(Device device);
    Task Delete(Device device);
    Task<Device> FindById(string deviceId);
}
