using Limit.Contract.Model;

namespace Limit.Contract.Interfaces
{
    public interface IInventoryDataService
    {
        Task<Inventory> AddAsync(InventoryCreator creator, Guid userId, CancellationToken token);

        Task<InventoryList> GetAsync(InventoryFilter inventoryFilter, Guid userId, CancellationToken token);
    }
}
