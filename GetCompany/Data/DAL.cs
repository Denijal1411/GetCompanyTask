using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface DAL<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T Get(T t);
        List<T> GetAll();


    }
}
