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
    [ApiController]
    [Route("[controller]")]
    public class InventoryController(IServiceProvider serviceProvider) : CommonControllerBase(serviceProvider)
    {        
        private readonly IInventoryDataService _inventoryDataService = serviceProvider.GetRequiredService<IInventoryDataService>();

        protected override string ErrorMessageFormat => "Ошибка при обработке запроса InventoryController::{method}: {message} {stackTrace}";

        [Authorize]
        [HttpPost("GetList")]

        public Task<IActionResult> GetListAsync([FromBody] InventoryFilter inventoryFilter)
        {
            return Execute((userId, token) => _inventoryDataService.GetAsync(inventoryFilter, userId, token), "GetListAsync");            
        }
    }
}
