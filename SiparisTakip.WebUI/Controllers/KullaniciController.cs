using SiparisTakip.Bll;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Entities.Model;
using SiparisTakip.Interfaces;
using SiparisTakip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisTakip.WebUI.Controllers
{
    public class KullaniciController : Controller
    {
        //  IKullaniciService kullaniciService = new KullaniciManager(new EFKullaniciRepository());
   
       //Ninject yapısıııııııı
        IKullaniciService kullaniciService;
        ICariService CariService;
        //Cari yide kullanacksak yazmalıyız constructer içindeee
      
        public KullaniciController(IKullaniciService kullaniciService, ICariService CariService)
        {
            this.kullaniciService = kullaniciService;
            this.CariService = CariService;
        }

        // GET: Kullanici
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(ViewKullanici kullanici) 
        {
            try {
                if (ModelState.IsValid)
                {
                    var User = kullaniciService.KullaniciGiris(kullanici.KullaniciKodu, kullanici.Parola);
                    if (User != null)
                    {
                        Session["Kullanici"] = User;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return View(kullanici);
                }
            }
            catch (Exception errorMessage) {
                ModelState.AddModelError("", errorMessage);
                return View(kullanici);
            }
            return View(kullanici);
            }

        public ActionResult Listele() 
        {           
            return View();
        }      
        public ActionResult ListelePartial() 
        {           
            return View(kullaniciService.GetAll());
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(Kullanici kullanici) 
        {      
            return View(kullaniciService.Add(kullanici));
        }    
        public ActionResult detay(int Id) 
        {
            return View(kullaniciService.Get(Id));
        }    
        [HttpGet]
        public ActionResult Update(int id) 
        {
            return View(kullaniciService.Get(id));
        }
        [HttpPost]
        public ActionResult Update(Kullanici kullanici)
        {
            return View(kullaniciService.Update(kullanici));
        }

        [HttpPost]
        public ActionResult sil(int id)
        {
            kullaniciService.Remove(id);
            return View("Listele");
        }
    }
}