using Address_Book_Data;
using Address_Book_Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service
{
   public interface IContactService :IGenericRepository<Contact>
    {
        public Task<Contact> GetContact(int id);
        public Task<List<Contact>> GetAllContacts();
        public Task <bool> CheckContactExist(Contact model);
        public void AddContact(Contact model);
        public void UpdateContact(Contact model);
        public void DeleteContact(int id);
    }
}
