﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Interfaces
{
   public interface IGenericService<T>:IDisposable
    {
        T Add(T entity);
        T Get(int id);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        bool Remove(int id);//entity id silmez nesne siler
        bool Remove(T entity);
        T Update(T entity);
    }
}
