using SiparisTakip.Cache;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Entities.Model;
using SiparisTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
   public class CacheFonksiyon
    {
        DefaultCacheProvider cache = new DefaultCacheProvider();
        public void CacheTemizleme() {
            
            cache.Remove(Enums.CacheKey.kategoriler.ToString());
            cache.Remove(Enums.CacheKey.OlcuBirimi.ToString()); 
        }
        public void CacheOlustur() {
            #region Kategori
            object kategoriCache = null;
            try
            {
                IGenericService<Tanim> genericManeger = new GenericManager<Tanim>(new EFGenericRepository<Tanim>());
                var kategori = genericManeger.GetAll(x => x.TanimGrupID == (int)Enums.TanimGrup.StokGrubu);
                if (kategori != null)
                    kategoriCache = kategori;
                else
                    throw new Exception("Kategori cache doldurulamadı.");
            }
            catch (Exception e)
            {
                Trace.WriteLine("Kategori Cache Doldurulamadı");
                throw new Exception("Kategori cache doldurulamadı.", e);
            }
            cache.Set(Enums.CacheKey.kategoriler.ToString(),kategoriCache);
            #endregion

            #region Ölçü birimi

            object olcuCache = null;
            try
            {
                IGenericService<Tanim> genericManeger = new GenericManager<Tanim>(new EFGenericRepository<Tanim>());
                var olcuBirim = genericManeger.GetAll(x => x.TanimGrupID == (int)Enums.TanimGrup.StokGrubu);
                if (olcuBirim != null)
                    olcuCache = olcuBirim;
                else
                    throw new Exception("Olcubirimi cache doldurulamadı.");
            }
            catch (Exception e)
            {
                Trace.WriteLine("Olcubirimi Cache Doldurulamadı");
                throw new Exception("Olcubirimi cache doldurulamadı.", e);
            }
            cache.Set(Enums.CacheKey.OlcuBirimi.ToString(), olcuCache);
            #endregion
        }
        public object kategoriGetir()
        {
            object value = null;
            try
            {
                var kategori = (List<Tanim>)(cache.Get(Enums.CacheKey.kategoriler.ToString()));
                if (kategori != null)
                {
                    value = kategori;
                }
            }
            catch (Exception e)
            {
                value = null;
                Trace.WriteLine("kategori cache'ten okunamadı." + e.Message);
                throw new Exception("kategori cache'ten okunamadı." + e);
            }
            return value;
        }
        public object cacheTanimGetir(string key) {
            object value=null;
            try
            {
           var tanim=(List<Tanim>)(cache.Get(key));
                if (tanim != null)
                {
                    value = tanim;
                }
            }
            catch (Exception e)
            {
                value = null;
                Trace.WriteLine("kategori cache'ten okunamadı." + e.Message);
                throw new Exception("kategori cache'ten okunamadı." + e);
            }
            return value;        
        }
    }
}
