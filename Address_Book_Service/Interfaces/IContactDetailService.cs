using Address_Book_Data;
using Address_Book_Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Service.Interfaces
{
   public interface IContactDetailService: IGenericRepository<ContactDetails>
    {
        public void AddContactDetail(ContactDetails model);
        public void UpdateContactDetails(ContactDetails model);
        public Task<ContactDetails> GetContactDetail(int id);
    }
}
