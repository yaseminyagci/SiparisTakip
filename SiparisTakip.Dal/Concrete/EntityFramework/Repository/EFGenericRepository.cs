using SiparisTakip.Dal.Abstract;
using SiparisTakip.Dal.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public /*abstract*/ class EFGenericRepository<T> : IGenericRepository<T> where T:class
    {
        public EFSiparisTakipContext context;

        //ilk önce bu sınıfı abstract oluşturmuştuk fakat herbir ulaşmak istediğimiz tablo için hem (abstract ve clasını)repository tanımlamamak
        //ve bu şekilde ulaşmak için abstract yapmayız bunun interface i abstract klasöründe ve orada kalıtım alıyoruz class burası olduğundan dolayı 
        //context de burada tanımlanmıştır eğer sadece abstract kısmını silip çalıştırırsak context den nullexception döner bu yüzden bu class ta aşağıdaki gibi constructer oluştururuz.
        // Bunu oluşturduktan sonra aönceki mimarimizde kullandığımız tasarımda burada contextleri oluşturmayıp bu classı kalıtım alan efcari ve ef stok kısmında oluşturmuştuk şimdi ise orada ki
        // constructer için dekini boşaltıp base deriz bu base ise tanımlı olduğu yerde o class hangi sınıftan kalıtım alırsa oranın constructerını çalıştırır. Oradaki constructer içinde ki cprtex kısmını
        //boşaltmamızın nedeni ise iki yerde de context oluşturması biz sadece bir context üzerinde çalışıp gereksi alan işgal etmemeye çalışacağız.
        public EFGenericRepository()
        {
            context = new EFSiparisTakipContext();
        }

        public T Add(T entity)
        {//kaydettiği veriyi tekrar geriye gönderiyoruz. Yani select yapamıza gerek yok
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing) {
            if (disposing)
            {
                context.Dispose();
            }
        }

        public T Get(int id)
        {
            var entity = context.Set<T>().Find(id);
            //izinleri veriyoruz burayı yapmasakta çalışırdı...
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().AsNoTracking().ToList();

        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsNoTracking().Where(predicate).ToList(); 
        }

        public bool Remove(int id)
        {
           return Remove(Get(id));

        }

        public bool Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges() > 0;
        }

        public T Update(T entity)
        {
            context.Set<T>().AddOrUpdate(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
