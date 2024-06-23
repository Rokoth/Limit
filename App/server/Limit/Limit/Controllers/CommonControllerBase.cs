using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Limit.Controllers
{
    public abstract class CommonControllerBase(IServiceProvider serviceProvider) : Controller
    {
        protected ILogger _logger = serviceProvider.GetRequiredService<ILogger<CommonControllerBase>>();
        protected IServiceProvider _serviceProvider = serviceProvider;

        protected abstract string ErrorMessageFormat { get; }

        protected InternalServerErrorObjectResult InternalServerError()
        {
            return new InternalServerErrorObjectResult();
        }

        protected InternalServerErrorObjectResult InternalServerError(object value)
        {
            return new InternalServerErrorObjectResult(value);
        }

        protected IActionResult ErrorRedirect(string errorMessage, string stackTrace)
        {
            _logger.LogError($"{errorMessage} {stackTrace}");
            return RedirectToAction("Index", "Error", new { Message = errorMessage });
        }

        protected async Task<IActionResult> Execute<T>(Func<Guid, CancellationToken, Task<T>> action, string method)
        {
            try
            {
                var userId = Guid.Parse(User.Identity.Name);
                var source = new CancellationTokenSource(30000);
                var response = await action(userId, source.Token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ErrorMessageFormat, method, ex.Message, ex.StackTrace);
                return BadRequest($"Ошибка при обработке запроса: {ex.Message}");
            }
        }
    }
}
