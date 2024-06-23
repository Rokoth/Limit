using Limit.Contract.Model;

namespace Limit.Contract.Interfaces
{
    public interface IMapDataService
    {
        Task<MapList> GetAsync(MapFilter mapFilter, Guid userId, CancellationToken token);
    }
}
