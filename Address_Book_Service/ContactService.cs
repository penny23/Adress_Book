using Address_Book_Data;
using Address_Book_Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service
{
    public class ContactService : GenericRepository<Contact>, IContactService
    {
        private AddressBookEntites _context;

        public ContactService( AddressBookEntites context)
            :base(context)
        {
            this._context = context;
        }

        public async Task<Contact> GetContact(int id)
        {
            var contact = await Get(id);
            if (contact == null)
            { }
            return contact;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await GetAll();
        
        }

        public async Task <bool> CheckContactExist(Contact model)
        {
            bool results = false;
            var contacts = await GetAll();
            var modelExists = contacts.ToList().Where(x => x.ContactNumber.Equals(model.ContactNumber)).FirstOrDefault();

            if (modelExists == null)
            {
                return results;
            }
            else
            {
                results = true;

            }
            return results;

        }

        public void AddContact(Contact model)
        {
            try
            {
                Add(model);
            }

            catch (Exception ex)
            { 
            
            }
        }
        public void UpdateContact(Contact model)
        {
            try
            {
                Update(model);
            }

            catch (Exception ex)
            {

            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                Delete(id);
            }

            catch (Exception ex)
            {

            }
        }
    }
}
