using AutoMapper;
using Address_Book_Data;
using Address_Book_Model;

namespace Adress_Book.DomainProfiles
{
    public class DomainMapperProfile:Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel,Contact>();
            CreateMap<ContactDetails, ContactDetailsViewModel>();
            CreateMap<ContactDetailsViewModel, ContactDetails>();
            CreateMap<ContactType, ContactTypeViewModel>();
            CreateMap<ContactTypeViewModel, ContactType>();

        }
    }
}
