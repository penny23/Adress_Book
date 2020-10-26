using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address_Book_Data;
using Address_Book_Model;
using Address_Book_Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Adress_Book.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]

    public class ContactController : ControllerBase
    { 
        private IContactService _contactService;
        private IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            this._contactService = contactService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllContacts")]
        [EnableCors("AllowOrigin")]
        public async Task <IActionResult> GetAllContactsAsync()
        {
            try 
            {
                var contacts = await _contactService.GetAllContacts();
                var contactsViewModel = _mapper.Map<IEnumerable<ContactViewModel>>(contacts);
                return Ok(contactsViewModel.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }
        [HttpGet]
        [Route("GetContact/{id}")]
        [Produces("application/json")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> GetContact( int id)
        {
            try
            {
                var contact = await _contactService.GetContact(id);
                var contactsViewModel = _mapper.Map<ContactViewModel>(contact);
                return Ok(contactsViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       

        [HttpPost]
        [Route("AddContact")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> AddContacts(ContactViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("contact model is empty");
                }

                var contact = _mapper.Map<Contact>(model);

                var modelExists = await _contactService.CheckContactExist(contact);
                if (modelExists == false)
                {
                    _contactService.AddContact(contact);

                }
                else {
                    return Conflict("Contact Number alreadly exists");
                }
                return Ok("User has been loaded successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}