using anthonyscheeresApi.Providers;
using AnthonyscheeresApi.Models;
using AnthonyscheeresApi.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyscheeresApi.Dao
{
    /**
* @author Anthony Scheeres
*/
     internal class ContactInfoDao
    {
        
        private DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        /**
* @author Anthony Scheeres
*/
         internal ContactInfoDao()
        {
        }
  
        /**
* @author Anthony Scheeres
*/
        internal void changeContactInfoByModelInDatabase(ContactInfoModel contactInfo)
        {
            //const query for updating each record of the table
            const string sqlQueryForChangingContactInfo = "update contact_information_owner set name = @name; update contact_information_owner set place = @place; update contact_information_owner set address = @address; update contact_information_owner set postal_code = @postal_code; update contact_information_owner set telephone = @telephone; update contact_information_owner set mail = @mail";

            using var connectionWithDatabase = ConnectionProvider.getProvide(); //start new Npgsql instance for connecting with an postgres database//start new Npgsql instance for connecting with an postgres database
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForChangingContactInfo, connectionWithDatabase);







            //Insert variables in prepared statment
            command.Parameters.AddWithValue("@name", contactInfo.name == null ? (object)DBNull.Value : contactInfo.name);
            command.Parameters.AddWithValue("@place", contactInfo.place ==null ? (object)DBNull.Value : contactInfo.place);
            command.Parameters.AddWithValue("@address", contactInfo.address==null ? (object)DBNull.Value : contactInfo.address);
            command.Parameters.AddWithValue("@postal_code", contactInfo.postal_code ==null ? (object)DBNull.Value : contactInfo.postal_code);
            command.Parameters.AddWithValue("@telephone", contactInfo.telephone ==null ? (object)DBNull.Value : contactInfo.telephone);
            command.Parameters.AddWithValue("@mail", contactInfo.mail ==null ? (object)DBNull.Value : contactInfo.mail);

            
            command.Prepare(); //Construct and optimize query

            //Execute query
            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }


        /**
* @author Anthony Scheeres
*/
        internal string getContactInfoAsJsonFormatFor()
        {
            string sqlQueryForChangingContactInfo = "select * from contact_information_owner;";
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForChangingContactInfo);
            return jsonString;
        }
    }
}
