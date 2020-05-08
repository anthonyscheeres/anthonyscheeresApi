using anthonyscheeresApi.Providers;
using AnthonyscheeresApi.Dao;
using AnthonyscheeresApi.Models;

namespace AnthonyscheeresApi.Services
{
     internal class ContactInfoService : TokenService
    {
        private readonly ContactInfoDao contactInfoDao = DaoProvider.getContact();

        internal string getContactInfoAsJsonFormatFor()
        {
            return contactInfoDao.getContactInfoAsJsonFormatFor();
        }

        internal string validateChangeContactInfo(string token, ContactInfoModel contactInfo)
        {
           
            //if token is invalide throw exception
            getPermissionFromDatabaseByTokenIsAdmin(token);
            //failed response by default
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;



            contactInfoDao.changeContactInfoByModelInDatabase(contactInfo);

            //change to success response and return 
            response = ResponseR.success.ToString();


            //return fail or success response
            return response;
        }


    }
}
