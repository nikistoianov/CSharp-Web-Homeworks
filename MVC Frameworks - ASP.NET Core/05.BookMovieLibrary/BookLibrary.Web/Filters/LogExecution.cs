using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookLibrary.Web.Filters
{
    public class LogExecution : IPageFilter, IActionFilter
    {
        private readonly ILogger<LogExecution> logger;
        private readonly Stopwatch stopwatch;

        public LogExecution(ILogger<LogExecution> logger, Stopwatch stopwatch)
        {
            this.logger = logger;
            this.stopwatch = stopwatch;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            LogInMessage(context.HttpContext.Request.Method, context.ActionDescriptor.DisplayName, context.ModelState.IsValid);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            LogOutMessage(context.HttpContext.Request.Method, context.ActionDescriptor.DisplayName);
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            LogInMessage(context.HttpContext.Request.Method, context.ActionDescriptor.DisplayName, context.ModelState.IsValid);
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            LogOutMessage(context.HttpContext.Request.Method, context.ActionDescriptor.DisplayName);
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            // we don't need to handle this method
        }

        private void LogInMessage(string httpMethod, string actionName, bool isModelStateValid)
        {
            this.logger.LogInformation($"Executing {httpMethod} {actionName}");
            this.logger.LogInformation($"Model state: {(isModelStateValid ? "valid" : "invalid")}");

            this.stopwatch.Restart();
        }

        private void LogOutMessage(string httpMethod, string actionName)
        {
            this.stopwatch.Stop();
            var seconds = this.stopwatch.Elapsed.TotalSeconds;

            this.logger.LogInformation($"Executed {httpMethod} {actionName} in {seconds}s");
        }
    }
}
