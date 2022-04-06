namespace Domain.Repositories;

public interface IEonNodeRepository : IRepository
{
    Task Add(EonNode node);
    void Update(EonNode node);
    void Delete(EonNode node);
    Task<EonNode> FindById(string eonNodeId);
}
