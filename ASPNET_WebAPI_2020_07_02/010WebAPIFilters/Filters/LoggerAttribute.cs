using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _010WebAPIFilters.Filters
{
    public class LoggerAttribute : ActionFilterAttribute
    {
        public LoggerAttribute()
        {

        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Debug.WriteLine(string.Format("LoggerAttribute - Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine(string.Format("LoggerAttribute - Action Method {0} executed at {1}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }
    }

    public class Logger1Attribute : Attribute, IActionFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Debug.WriteLine(string.Format("Logger1Attribute - Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

            var result = continuation();

            result.Wait();

            Debug.WriteLine(string.Format("Action Method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            return result;
        }
    }
}