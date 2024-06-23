using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Limit.Controllers
{
    public abstract class CommonControllerBase : Controller
    {
        protected ILogger _logger;
        protected IServiceProvider _serviceProvider;

        public CommonControllerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger<CommonControllerBase>>();
        }

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
    }
}
