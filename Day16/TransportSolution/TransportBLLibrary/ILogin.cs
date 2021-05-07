using System;
using System.Collections.Generic;
using System.Text;

namespace TransportBLLibrary
{
    public interface ILogin<T>
    {
        bool Add(T t);
        bool Login(T t);
    }
}
