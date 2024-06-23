using Limit.Contract.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;
using Limit.Contract.Model;

namespace Limit.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacteristicController(IServiceProvider serviceProvider) : CommonControllerBase(serviceProvider)
    {
        protected override string ErrorMessageFormat => "Ошибка при обработке запроса CharacteristicController::{method}: {message} {stackTrace}";
        private readonly ICharacteristicDataService _characteristicDataService = serviceProvider.GetRequiredService<ICharacteristicDataService>();

        
        [HttpPost("GetList")]

        public Task<IActionResult> GetListAsync([FromBody] CharacteristicFilter characteristicFilter)
        {
            return Execute((userId, token) => _characteristicDataService.GetAsync(characteristicFilter, userId, token), "GetListAsync");           
        }
        
        [HttpPost("GetItem")]

        public Task<IActionResult> GetItemAsync([FromBody] Guid id)
        {
            return Execute((userId, token) => _characteristicDataService.GetAsync(id, userId, token), "GetItemAsync");
        }

        [HttpPost("Update")]

        public Task<IActionResult> UpdateAsync([FromBody] CharacteristicUpdater updater)
        {
            return Execute((userId, token) => _characteristicDataService.UpdateAsync(updater, userId, token), "UpdateAsync");
        }
    }
}
