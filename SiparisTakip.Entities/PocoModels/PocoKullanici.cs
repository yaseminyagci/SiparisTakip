using SiparisTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Entities.PocoModels
{
   public class PocoKullanici/*:Kullanici*/
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public byte YetkiID { get; set; }

    }
}
