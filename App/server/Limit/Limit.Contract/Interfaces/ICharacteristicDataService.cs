using Limit.Contract.Model;

namespace Limit.Contract.Interfaces
{
    public interface ICharacteristicDataService
    {
        Task<CharacteristicList> GetAsync(CharacteristicFilter characteristicFilter, Guid userId, CancellationToken token);

        Task<Characteristic> GetAsync(Guid id, Guid userId, CancellationToken token);

        Task<Characteristic> UpdateAsync(CharacteristicUpdater updater, Guid userId, CancellationToken token);
    }
}
