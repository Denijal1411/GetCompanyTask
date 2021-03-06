using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DAL<T>
    {
        public abstract void Add(T t);
        public abstract void Delete(T t);
        public abstract void Update(T t);
        public abstract T Get(T t);
        public abstract List<T> GetAll();


    }
}
