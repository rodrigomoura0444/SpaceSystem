using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSystemv2.Infraestrutura.Repository.Interfaces
{

    /// <summary>
    /// Generic Method to acess data base items
    /// </summary>
    /// <typeparam name="T"> Models/Domain</typeparam>
    /// <typeparam name="TID">Models/Domain/GUID ID</typeparam>
    public interface IGenericRepository<T, TID>
    {

        Task<List<T>> GetAllAsync();
        Task<T?> GetbyIDAsync(TID id);

        Task<T> CreateAsync(T entity);

        Task<T?> UpdateAsync(TID id, T updatedEntity);

        Task<T?> DeleteAsync(TID id);
    }
}
