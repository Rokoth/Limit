using Limit.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limit.Contract.Interfaces
{
    public interface ICharacteristicDataService
    {
        Task<CharacteristicList> GetAsync(CharacteristicFilter characteristicFilter, Guid userId, CancellationToken token);
    }
}
