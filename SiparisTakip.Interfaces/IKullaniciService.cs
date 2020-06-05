﻿using SiparisTakip.Entities.Model;
using SiparisTakip.Entities.PocoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Interfaces
{
  public interface IKullaniciService:IGenericService<Kullanici>
    {
        PocoKullanici KullaniciGiris(string kullaniciAdi, string sifre);



    }
}
