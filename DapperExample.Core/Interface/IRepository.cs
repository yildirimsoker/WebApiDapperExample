using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Core.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);

    }
}
