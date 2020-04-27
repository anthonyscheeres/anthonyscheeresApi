using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyscheeresApi.Models
{
     public class ContactInfoModel
    {
         public string name { get; set; }
         public string place { get; set; }
         public string address { get; set; }
         public string postal_code { get; set; }

         public string telephone { get; set; }
         public string mail { get; set; }

         public ContactInfoModel(string name, string place, string address, string postal_code, string telephone, string mail)
        {
            this.name = name;
            this.place = place;
            this.address = address;
            this.postal_code = postal_code;
            this.telephone = telephone;
            this.mail = mail;
        }




         public ContactInfoModel()
        {
        }
    }
}
