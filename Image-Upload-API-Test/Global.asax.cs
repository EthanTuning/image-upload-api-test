using System.Web.Http;

namespace Image_Upload_API_Test {

    public class WebApiApplication : System.Web.HttpApplication {

        protected void Application_Start() {

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

    }

}
