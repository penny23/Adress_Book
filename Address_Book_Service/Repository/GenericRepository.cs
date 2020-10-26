using Address_Book_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service.Repository
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class
    {
        private readonly AddressBookEntites _context;

        public GenericRepository(AddressBookEntites context)
        {
            this._context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                throw new Exception("record cannot be found for deletion");
            }

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
