using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    [Controller]
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public string getCurrentUrl(IHttpContextAccessor httpcontextaccessor)
        {
            var request = httpcontextaccessor.HttpContext.Request;

            var absoluteUri = string.Concat(
                        request.Scheme,
                        "://",
                        request.Host.ToUriComponent(),
                        request.QueryString.ToUriComponent());
            return absoluteUri;
        }
    }
}