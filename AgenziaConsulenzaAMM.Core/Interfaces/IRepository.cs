using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FetchAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
