using Limit.Contract.Model;

namespace Limit.Contract.Interfaces
{
    public interface IPersonDataService
    {
        Task<PersonList> GetAsync(PersonFilter personFilter, Guid userId, CancellationToken token);
        Task<Person> GetAsync(Guid id, Guid userId, CancellationToken token);
    }
}
