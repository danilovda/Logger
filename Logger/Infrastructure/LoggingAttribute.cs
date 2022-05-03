using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace WebApplication1.Infrastructure
{
    public class LoggingAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LoggingAttribute> _logger;

        public LoggingAttribute(ILogger<LoggingAttribute> logger)
        {
            _logger = logger;
        }

        private Stopwatch actionTimer;
        private Stopwatch resultTimer;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            actionTimer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            actionTimer.Stop();
            string message = $"Действие для {context.ActionDescriptor.DisplayName} = {actionTimer.Elapsed}";
            
            _logger.LogInformation(message);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            resultTimer = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            resultTimer.Stop();
            string message = $"Результат для {context.ActionDescriptor.DisplayName} = {resultTimer.Elapsed}";
            
            _logger.LogInformation(message);
        }

    }
}
