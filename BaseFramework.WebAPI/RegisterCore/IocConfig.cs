using Autofac;
using Autofac.Integration.WebApi;
using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Busines.ProjectBaseBusinesService;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Dal;
using BaseFramework.MapConfig.Configprofile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace BaseFramework.WebAPI.RegisterCore
{
    public class IocConfig
    {
        public static void Configure()
        {


            GlobalConfiguration.Configuration.DependencyResolver = IocContainerConfig.RegisterDependencies();


        }

    }
}