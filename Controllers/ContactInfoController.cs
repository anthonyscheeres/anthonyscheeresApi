﻿using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
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



        // PUT: api/ContactInfo/ChangeContactInfo/{token}
        [Route("changeContactInfo")]
        [HttpPut("{token}")]
        public string changeContactInfo(string token, [FromBody] ContactInfoModel contactInfo)
        {
            return contactInfoService.validateChangeContactInfo(token, contactInfo);
        }
    }
}
