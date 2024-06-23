using Limit.Common;
using Limit.LimitDeployer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Limit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : CommonControllerBase
    {
        private readonly IDeployService deployService;
        private readonly IErrorNotifyService errorNotifyService;

        public CommonController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<CommonController>>();
            deployService = serviceProvider.GetRequiredService<IDeployService>();
            errorNotifyService = serviceProvider.GetRequiredService<IErrorNotifyService>();
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }

        [HttpGet("deploy")]
        public async Task<IActionResult> Deploy()
        {
            try
            {
                await deployService.Deploy();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка при раскатке базы данных: {message} {stackTrace}", ex.Message, ex.StackTrace);
                return InternalServerError($"Ошибка при раскатке базы данных: {ex.Message}");
            }
        }
    }
}
