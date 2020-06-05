using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Cache
{
    // abstract lar mecburi olarak dolduruulur
    //cache için dll lazım onlar ise
    // add referance ile system.runtime.cache
    public class DefaultCacheProvider : cacheProvider
    {
        //Objectcache cache metodları ile işlem yapacağımız sınıftır
        //ile ekleme felan filan yapıyorset yapacağımız yer oluyor.
        ObjectCache _cache;
        //cache cache ile ilgili özellikleri tutuyor.
        //hangi callback çalışacak öncelik durumları gibi özellikleri tutuyor.
        CacheItemPolicy _policy;
        public DefaultCacheProvider()
        {
            Trace.WriteLine("Cache Başlatıldı");
            _cache = MemoryCache.Default;
            _policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable,//datayı ben yıkana kadar silinmesin
             // RemovedCallback = new CacheEntryRemovedCallback(RemovedCallBack)//yıkıldığında çalışır böylede çalışır normalde
                RemovedCallback=RemovedCallBack
            
            };
        }

        private void RemovedCallBack(CacheEntryRemovedArguments arguments)
        {
            Trace.WriteLine("Cache Yıkıldı");
            Trace.WriteLine("Key:" + arguments.CacheItem.Key);
            Trace.WriteLine("Value:" + arguments.CacheItem.Value);
            Trace.WriteLine("RemoveReason:" + arguments.RemovedReason);
        }
        public override object Get(string key)
        {
            object item;
            try 
            {
                item = _cache.Get(key);
                if (item == null) 
                {
                    Trace.WriteLine("Cache getirilemedi.");
                    throw new Exception("Cache getirilemedi");
                }
            } 
            catch (Exception e) 
            {
                item = null;
                Trace.WriteLine("Csche getirilemedi."+e.Message);
                throw new Exception("Cache getirilemedi"+e.Message);
            }
            return item;
        }

        public override bool IsExist(string key)
        {
            return _cache.Any(x => x.Key == key);
        }

        public override void Remove(string key)
        {
            if (IsExist(key))
                _cache.Remove(key);
        }

        public override void Set(string key, object value)
        {
            _cache.Set(key,value,_policy);//_policy cachin özelliği bunuda istiyor
        }
    }
}
