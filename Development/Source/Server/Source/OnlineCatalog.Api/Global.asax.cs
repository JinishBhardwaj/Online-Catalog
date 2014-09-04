using System.Web.Http;
using OnlineCatalog.Api.Helpers.UI;

namespace OnlineCatalog.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperBootstrapper.Initialize();
        }
    }
}
