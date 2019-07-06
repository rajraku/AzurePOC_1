using AppAdapter;
using CommonModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace TodoWebAPI.GlobalFilter
{
    public class LogTransactionFilter : ActionFilterAttribute
    {
        private ILogServiceAdapter _logServiceAdapter;

        public LogTransactionFilter(ILogServiceAdapter logServiceAdapter)
        {
            _logServiceAdapter = logServiceAdapter;
        }


        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpMethod = context?.HttpContext?.Request?.Method;

            if (httpMethod?.Equals("Post", StringComparison.InvariantCultureIgnoreCase) == true ||
                httpMethod?.Equals("Put", StringComparison.InvariantCultureIgnoreCase) == true ||
                httpMethod?.Equals("Delete", StringComparison.InvariantCultureIgnoreCase) == true)
            {
                RequestLog reqLog = new RequestLog();
                reqLog.Method = httpMethod;
                Guid idKey = Guid.Empty; 
                if (context.ActionArguments.Keys.Contains("id") &&
                    Guid.TryParse(context.ActionArguments["id"].ToString(), out idKey))
                {
                    reqLog.Id = idKey;
                }

                var message = JsonConvert.SerializeObject(reqLog);
                _logServiceAdapter.Log(message);
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
