namespace Domain.Repositories;

public interface IEonNodeRepository
{
    Task Add(EonNode node);
    Task Update(EonNode node);
    Task Delete(EonNode node);
    Task<EonNode> FindById(string eonNodeId);
}
