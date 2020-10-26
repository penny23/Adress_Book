using Address_Book_Data;
using Address_Book_Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service
{
    public interface IContactTypeService: IGenericRepository<ContactType>
    {
        public Task<List<ContactType>> GetAllContactTypes();
    }
}
