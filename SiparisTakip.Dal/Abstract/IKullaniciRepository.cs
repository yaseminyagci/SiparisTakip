﻿using SiparisTakip.Entities.Model;
using SiparisTakip.Entities.PocoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Dal.Abstract
{
public interface IKullaniciRepository:IGenericRepository<Kullanici>    
    {
        Kullanici KullaniciGiris(string kullaniciAdi, string Password);
    }
}
