using Limit.Contract.Model;

namespace Limit.Contract.Interfaces
{
    public interface IInventoryDataService
    {
        Task<InventoryList> GetAsync(InventoryFilter inventoryFilter, Guid userId, CancellationToken token);
    }
}
