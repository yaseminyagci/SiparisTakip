using SiparisTakip.Bll;
using SiparisTakip.Dal.Abstract;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Entities.Model;
using SiparisTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisTakip.WebUI.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        ICariService context = new CariManager(new EFCariRepository());
        //yukarıdaki tanımı normalde repositoryi oluşturduğumuz için alabildik fakat oluşturmadanda alttaki gibi generic kısmından çekebiliriz gerekli işlemleri yaparak.
        //Allt generic kullandığımız için stok için ayrı tasarlanan metodlara ulaşamadık ve sadece generic sınıfının metodlarına ulaşabildik.
               
        IGenericService<Cari> CariService = new GenericManager<Cari>(new EFGenericRepository<Cari>()); 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CariList()
        {
            var liste = context.GetAll(x=>x.CariID>0);
            var liste2 = CariService.GetAll();
            return View(liste2);
        }

        public ActionResult _partialCari() {
            var liste =CariService.GetAll();
            return View(liste);
        }
    }
}