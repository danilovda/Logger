using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication1.Infrastructure
{
    public class ProfileAttribute: ActionFilterAttribute
    {
        private Stopwatch timer;

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    timer = Stopwatch.StartNew();
        //}

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    timer.Stop();
        //    string message = $"На выполнение метода {context.ActionDescriptor.DisplayName} затрачено {timer.Elapsed}";

        //    StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true);
        //    streamWriter.WriteLine(message);
        //    streamWriter.Close();
        //}

        //--------------------

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();

            // до вызова делегата ActionExecutionDelegate, код который запустится перед методом действия
            await next();
            // после вызова делегата ActionExecutionDelegate, код который запустится по завершению метода действия

            timer.Stop();
            string message = $"На выполнение метода {context.ActionDescriptor.DisplayName} затрачено {timer.Elapsed}";

            StreamWriter streamWriter = new("App_Data/log.txt", true);
            await streamWriter.WriteLineAsync(message);
            streamWriter.Close();
        }

    }
}
