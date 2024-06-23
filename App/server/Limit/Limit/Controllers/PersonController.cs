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
        private const string ErrorMessageFormat = "Ошибка при обработке запроса PersonController::{method}: {message} {stackTrace}";
        private readonly IPersonDataService _personDataService = serviceProvider.GetRequiredService<IPersonDataService>();

        [Authorize]
        [HttpPost("GetList")]

        public async Task<IActionResult> GetListAsync([FromBody] PersonFilter personFilter)
        {
            try
            {
                var userId = Guid.Parse(User.Identity.Name);
                var source = new CancellationTokenSource(30000);
                var response = await _personDataService.GetAsync(personFilter, userId, source.Token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ErrorMessageFormat, "GetListAsync", ex.Message, ex.StackTrace);
                return BadRequest($"Ошибка при обработке запроса: {ex.Message}");
            }
        }
    }
}
