using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address_Book_Model;
using Address_Book_Service;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adress_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ContactTypeController : ControllerBase
    {
        private IContactTypeService _contactTypeService;
        private IMapper _mapper;

        public ContactTypeController(IContactTypeService contactTypeService, IMapper mapper)
        {
            this._contactTypeService = contactTypeService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllContactTypes")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAllContactsTypes()
        {
            try
            {
                var contactTypes = await _contactTypeService.GetAllContactTypes();
                var contactTypesViewModel = _mapper.Map<IEnumerable<ContactTypeViewModel>>(contactTypes);
                return Ok(contactTypesViewModel.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }




    }
}