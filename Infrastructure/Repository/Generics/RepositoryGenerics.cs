using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGenerics<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _Context;

        public RepositoryGenerics()
        {
            _Context= new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objeto)
        {      
            using (var data = new ContextBase(_Context))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }      
               
        public async Task Delete(T objeto)
        {
            using(var data = new ContextBase(_Context))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }

        }       
                
        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_Context))
            {
               return await data.Set<T>().FindAsync(Id);
                
            }
        }       
                
        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_Context))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }

        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextBase(_Context))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }

        }
        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }

    }
}
