using AnthonyscheeresApi.Models;
using AnthonyscheeresApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AnthonyscheeresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        ContactInfoService contactInfoService = new ContactInfoService();


        // GET: api/ContactInfo/getContactInfo
        [Route("getContactInfo")]
        [HttpGet]
        public string getContactInfo()
        {

            return contactInfoService.getContactInfoAsJsonFormatForPublicUsers();
        }



        // PUT: api/ContactInfo/ChangeContactInfo?token={token}
        [Route("changeContactInfo")]
        [HttpPut("{token}")]
        public string changeContactInfo([FromBody] ContactInfoModel contactInfo, [FromQuery]  string token)
        {
            
            return contactInfoService.validateChangeContactInfo(token, contactInfo);
        }
    }
}
