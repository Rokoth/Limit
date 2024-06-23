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
    public class PersonController(IServiceProvider serviceProvider) : CommonControllerBase(serviceProvider)
    {
        protected override string ErrorMessageFormat => "Ошибка при обработке запроса PersonController::{method}: {message} {stackTrace}";
        private readonly IPersonDataService _personDataService = serviceProvider.GetRequiredService<IPersonDataService>();

        [Authorize]
        [HttpPost("GetList")]

        public  Task<IActionResult> GetListAsync([FromBody] PersonFilter personFilter)
        {
            return Execute((userId, token) => _personDataService.GetAsync(personFilter, userId, token), "GetListAsync");            
        }

        [HttpPost("GetItem")]

        public Task<IActionResult> GetItemAsync([FromBody] Guid id)
        {
            return Execute((userId, token) => _personDataService.GetAsync(id, userId, token), "GetItemAsync");
        }
    }
}
