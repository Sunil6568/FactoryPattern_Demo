using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExternalServices;
using ExternalServices.Stubs;

namespace Tariffs
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
            DependencyResolver.SetResolver(new BasicDependencyResolver());
        }
    }

    public class BasicDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return serviceType == typeof(DiscountController) ? 
                new DiscountController(new CustomerServiceStub(), new AccountsServiceStub(), new PackageServiceStub()) :
                null;
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            return new object[0];
        }
    }
}