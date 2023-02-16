using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceGenericaApp<T> where T : class
    {
        Task Add(T objeto);

        Task<T> Update(T objeto);

        Task Delete(T objeto);

        Task<T> GetEntityById(int Id);

        Task<List<T>> List();
    }
}
