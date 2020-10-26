using Address_Book_Data;
using Address_Book_Service.Interfaces;
using Address_Book_Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service
{
    public class ContactDetailsService: GenericRepository<ContactDetails>,IContactDetailService
    {
        private AddressBookEntites _context;

        public ContactDetailsService( AddressBookEntites context)
            :base(context)
        {
            this._context = context;
        }

        public void AddContactDetail(ContactDetails model)
        {
            try {
                Add(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }
        public void UpdateContactDetails(ContactDetails model) {

            try
            {
               Update(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ContactDetails> GetContactDetail(int id)
        {
            var contact = await Get(id);
            if (contact == null)
            {
                throw new Exception("contact Detail Not Found");
            }
            return contact;

        }

    }
}
