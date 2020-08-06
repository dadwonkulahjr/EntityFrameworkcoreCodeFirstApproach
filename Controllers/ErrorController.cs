using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkcoreCodeFirstApproach.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this._logger = logger;
        }
        [Route("/Error/{statusCode}")]
        public IActionResult ErrorHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The resource you requested could not be found.";
                    _logger.LogWarning($"The path: {statusCodeResult.OriginalPath}");
                    _logger.LogWarning($"The query strings: {statusCodeResult.OriginalQueryString}");
                    break;
                default:
                    break;
            }
            return View("NotFound");
        }

        [Route("/Error")]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Error()
        {
            var result = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
            _logger.LogError($"An error occured on the following path {result.Path}");
            _logger.LogError($"Exception Message: {result.Error.Message}");
            _logger.LogError($"Exception StackTrace: {result.Error.StackTrace}");
            return View("Error");
        }
    }
}
