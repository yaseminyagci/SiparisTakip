using Ninject;
using SiparisTakip.Bll;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiparisTakip.WebUI.App_Start
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBllBind();
        }

        private void AddBllBind()
        {
            this.kernel.Bind<IKullaniciService>().To<KullaniciManager>().WithConstructorArgument("kullaniciRepository", new EFKullaniciRepository());
            this.kernel.Bind<IStokService>().To<StokManager>().WithConstructorArgument("stokRepository", new EFStokRepository()); 
            this.kernel.Bind<ICariService>().To<CariManager>().WithConstructorArgument("cariRepository", new EFCariRepository()); 
 
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType==null?null:(IController)kernel.Get(controllerType) ;
        }
    }
}