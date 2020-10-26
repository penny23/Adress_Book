using Address_Book_Data;
using Address_Book_Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service
{
   public class ContactTypeService: GenericRepository<ContactType>,IContactTypeService
    {
        private AddressBookEntites _context;

        public ContactTypeService(AddressBookEntites context)
            : base(context)
        {
            this._context = context;
        }

        public async Task<List<ContactType>> GetAllContactTypes()
        {
            return await GetAll();
        }
    }
}
