using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using SportsShop.Domain.Entities;
using SportsShop.Domain.Abstract;
using System.Collections.Concurrent;
using SportsShop.Domain.Concrete;

namespace SportsShop.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {


            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}