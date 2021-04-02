using RestAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        T GetById(int id);
        Task UpserAsync(T entity);
        Task DeleateById(int id);
        T FindById(int id);
        Task ContextSaveChangesAsync();
        Task RemoveProducts(T entity, int amount);
        Task AddToSalesHistory(BoughtProduct entity);
        }
}
