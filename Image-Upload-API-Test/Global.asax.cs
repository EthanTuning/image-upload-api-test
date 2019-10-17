using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Image_Upload_API_Test {

    public class WebApiApplication : System.Web.HttpApplication {

        protected void Application_Start() {

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

    }

}
