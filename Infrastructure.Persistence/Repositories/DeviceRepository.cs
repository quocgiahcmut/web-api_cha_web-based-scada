namespace Infrastructure.Persistence.Repositories;

public class DeviceRepository : BaseRepository, IDeviceRepository
{
    public DeviceRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task Add(Device device)
    {
        await _context.Devices.AddRangeAsync(device);
    }

    public  void Delete(Device device)
    {
        _context.Devices.Remove(device);
    }

    public async Task<Device?> FindById(string deviceId)
    {
        return await _context.Devices
            .Include(d => d.Tags)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == deviceId);
    }

    public void Update(Device device)
    {
        _context.Devices.Update(device);
    }

    public async Task<IEnumerable<Device>> GetAllDevice()
    {
        return await _context.Devices
            .AsNoTracking()
            .ToListAsync();
    }
}
