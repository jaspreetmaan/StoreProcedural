using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProcedural.Data;
using StoreProcedural.Dto.ContactDto;
using StoreProcedural.Models;
using StoreProcedural.Service;
using System.Data;
using System.Data.SqlClient;

namespace StoreProcedural.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ContactController : ControllerBase
    {
        public IContactService contactService { get; }

        public ContactController(IContactService _contactService)
        {
            contactService = _contactService;
        }
        
        


        [HttpPost("AddContact")]
        public ActionResult UpdateContact(GetContactDto contact)
       {
            return Ok(contactService.AddData(contact));
        }
        [HttpGet("GetContacts")]
        public async  Task <ActionResult>GetContacts()
        {
            try
            {
                
                return Ok(contactService.GetContacts());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);            }
        }

        [HttpPost("UpdateContact")]
        public async Task<ActionResult> UpdateContact(Contacts contact)
        {
            return Ok(contactService.UpdateContact(contact));
        }

        [HttpPost("DeleteContact")]
        public async Task <ActionResult> DeleteContact(int id)
        {
            return Ok(contactService.DeleteContact(id));
        }


        
        


    }
}
