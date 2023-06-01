using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Repository.Interfaces
{
    internal interface IRepository<T>
    {
        bool Add(T entity);
        bool Delete(int id);
        T Get(int id);
        bool Update(T entity);
        List<T> GetAll();
    }
}
