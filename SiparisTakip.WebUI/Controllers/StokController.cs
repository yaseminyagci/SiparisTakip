using SiparisTakip.Bll;
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
    public class StokController : Controller
    {
        // GET: Stok
        IStokService stokService = new StokManager(new EFStokRepository());
       // IGenericService<Kullanici> kulSetvice=new GenericManager<Kullanici>(new EFGenericRepository<Kullanici>());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StokList()
        {
            var liste = stokService.GetAll();
          //  var liste2 = kulSetvice.GetAll();
            return View(liste);
        }
        public ActionResult StokKarti()
        {
            CacheFonksiyon cache = new CacheFonksiyon();

          //  ViewBag.kategoriler = cache.kategoriGetir();
            ViewBag.OlcuBirimi = cache.cacheTanimGetir(Enums.CacheKey.OlcuBirimi.ToString());
           
            return View();
        }
    }
}