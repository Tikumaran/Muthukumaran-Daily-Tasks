using System;
using System.Collections.Generic;
using System.Text;

namespace TransportBLLibrary
{
    public interface IRepo<T>
    {
        bool Add(T t);
        bool Update(T t);
        bool UpdateEmployee(T t);
        ICollection<T> GetAll();
    }
}
