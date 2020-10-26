using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service.Repository
{
   public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
        void Delete(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);

    }
}
