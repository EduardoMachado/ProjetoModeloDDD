using ProjetoModelo.MVC.AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.Infra.Repositories;

namespace ProjetoModelo.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            var container = new Container();


            //container.Register(typeof(IWordFacade<,,,>), typeof(WordImpl<,,,>));


            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>),Lifestyle.Singleton);// (Lifestyle.Singleton);
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Singleton);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Singleton);

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Singleton);// (Lifestyle.Singleton);
            container.Register<IClienteService, ClienteService>(Lifestyle.Singleton);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Singleton);

            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Singleton);// (Lifestyle.Singleton);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Singleton);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Singleton);
                   

            container.Verify();

            DependencyResolver.SetResolver(
               new SimpleInjectorDependencyResolver(container));
        }
    }
}
