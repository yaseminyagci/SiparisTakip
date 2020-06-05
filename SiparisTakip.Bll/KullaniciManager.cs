using SiparisTakip.Dal.Abstract;
using SiparisTakip.Entities.Model;
using SiparisTakip.Entities.PocoModels;
using SiparisTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
    public class KullaniciManager :GenericManager<Kullanici>,IKullaniciService
    {
        IKullaniciRepository kullaniciRepository;
        public KullaniciManager(IKullaniciRepository kullaniciRepository):base(kullaniciRepository)
        {
            this.kullaniciRepository = kullaniciRepository;                
        }
        PocoKullanici IKullaniciService.KullaniciGiris(string kullaniciAdi, string sifre)
        {
            if (string.IsNullOrEmpty(kullaniciAdi.Trim()))
            {
                throw new Exception("Kullanıcı Adı Boş Geçilemez.");
            }
            if (string.IsNullOrEmpty(sifre.Trim())) 
            {
                throw new Exception("Parola Boş Geçilemez.");
            }
            var parola = new ToPasswordRepository().Md5(sifre);
            var kullanici = kullaniciRepository.KullaniciGiris(kullaniciAdi, parola);
            if (kullanici == null)
            {
                throw new Exception("Kullanıcı Adınızı veya parolanızı kontrol ediniz.");
            }
            else
            {
                return new PocoKullanici() { 
                KullaniciID=kullanici.KullaniciID,
                KullaniciAdi=kullanici.KullaniciAdi,
                KullaniciSoyadi=kullanici.KullaniciSoyadi,
                YetkiID=kullanici.YetkiID
                };
            }
            //return kullaniciRepository.KullaniciGiris(kullaniciAdi, sifre);
        }
    }
}
