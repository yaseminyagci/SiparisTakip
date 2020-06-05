using SiparisTakip.Bll;
using SiparisTakip.Cache;
using SiparisTakip.WebUI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SiparisTakip.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Ninject için kullanacağızzzz
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            cacheProvider.Instance = new DefaultCacheProvider();//cache mekanizmasını çalıştırıyoruz.
            CacheFonksiyon fonksiyon = new CacheFonksiyon();
            fonksiyon.CacheTemizleme();
            fonksiyon.CacheOlustur();


        }
    }
}
