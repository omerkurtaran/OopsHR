using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BaseFramework.MapConfig.Configprofile
{
    public class IocContainerConfig
    {
        public static AutofacWebApiDependencyResolver RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var callingAssembly = Assembly.GetCallingAssembly().GetName().Name;
            if (callingAssembly.Contains("WebUI"))
            {
                builder.RegisterControllers(Assembly.Load("BaseFramework.WebUI"));
            }
            else if (callingAssembly.Contains("WebAPI"))
            {
                builder.RegisterApiControllers(Assembly.Load("BaseFramework.WebAPI"));
            }
            //builder.RegisterControllers(Assembly.Load("BaseFramework.WebAPI"));
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<UnitofWork>().As<IUnitofWork>().InstancePerLifetimeScope();
            builder.RegisterType<BaseFrameworkEntities>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("BaseFramework.Busines"))
                .Where(z => z.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            IContainer container = builder.Build();

            if (callingAssembly.Contains("WebAPI"))
            {
                var resolver = new AutofacWebApiDependencyResolver(container);
                return resolver;
            }
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return null;
        }
    }
}
