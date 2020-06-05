using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Cache
{
   public abstract class cacheProvider
    {
        /*cache de veri eklemek için set ekleriz        
            Cache de veri object alır object verir
            Cache den veri sileceksek key ile yaparız key ile veri setini işaret ettiğinden dolayı
            abstract sınavlarda m değişken ve gövdeli metod tanımlanabilir.
            eğer normal class da tasarlayıp set içine bişeyler eklersek
            sonrada bunu değiştirmek istersek buraya gelip değiştirmemiz gerekecek
            fakat bu yapıda yeni ekleme yapacağız
            Aslında bu bir şablondur ve bunu o sınıfta kullanırız.
            Çok biçimlilik bir örneğidir çünkü aynı metodu yazıp farklı işler yapıyor kullanılan yerde
            İnterface kulanmamaızın nedeni ise abstract ile değişken ve metod göcdesi tanımlayabiliyoruz
            Interface sedece imza alır yani gövde içi doldurulamaz.
            daha fazlaözellik var burada
             
             */
        public static int CacheDuration = 60;//bellekte bir tane referance olması için static yaptık
       
        public static cacheProvider Instance;
        //cache providerın kullanıldığı yani inherit edildiği yerden nesne türetilirse static olarak burada tutulur.
        public abstract void Set(string key, object value);
        public abstract object Get(string key);
        public abstract void Remove(string key);
        public abstract bool IsExist(string key);
    }
}
