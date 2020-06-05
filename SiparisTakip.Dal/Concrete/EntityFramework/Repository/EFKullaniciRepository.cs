using SiparisTakip.Dal.Abstract;
using SiparisTakip.Entities.Model;
using SiparisTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public class EFKullaniciRepository : EFGenericRepository<Kullanici>, IKullaniciRepository
    {
        public EFKullaniciRepository():base()
        {

        }
        public Kullanici KullaniciGiris(string kullaniciAdi, string Password)
        {
            var kul= context.Kullanici.Where(x => x.KullaniciKodu == kullaniciAdi && x.Sifre == Password).SingleOrDefault();
            return kul;
        }
    }
}
