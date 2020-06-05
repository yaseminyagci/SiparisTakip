using SiparisTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Interfaces
{
    public interface ICariService : IGenericService<Cari>
    {
        //cari ile ilgili özel bir metod olacaksa burada yazılır.
        List<Cari> CariHesapEkstresi(int cariId);
    }
}
