using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address_Book_Data;
using Address_Book_Model;
using Address_Book_Service;
using Address_Book_Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adress_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {

        private IContactDetailService _contactDetailService;
        private IMapper _mapper;

        public ContactDetailController(IContactDetailService contactDetailService, IMapper mapper)
        {
            this._contactDetailService = contactDetailService;
            this._mapper = mapper;
        }

        
        [HttpGet]
        [Route("GetContactDetail/{id}")]
        [Produces("application/json")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> GetContactDetail(int id)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetContactDetail(id);
                var ViewModel = _mapper.Map<ContactDetailsViewModel>(contactDetail);
                return Ok(ViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("AddContactDetail")]
        [EnableCors("AllowOrigin")]
        public ActionResult AddContactDetail(ContactDetailsViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("contact detail model is empty");
                }

                var contact = _mapper.Map<ContactDetails>(model);

                _contactDetailService.AddContactDetail(contact);

                return Ok("Contact has been loaded successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}