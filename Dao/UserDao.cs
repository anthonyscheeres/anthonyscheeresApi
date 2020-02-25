using ChantemerleApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{

    /**
	 * @author Anthony Scheeres
	 */
    public class UserDao
    {
        private string cs = DataModel.databaseCredentials.cs;

        /**
	 * @author Anthony Scheeres
	 */
        internal void sendQueryToDatabaseToRegisterUser(string username, string password, string email)
        {
            bool is_super_user = false;
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();
           

           var sqlQueryForRegistingUser = "INSERT INTO app_users(username, password, is_super_user, email, token) VALUES(@username, @password, @is_super_user, @email, concat(md5(@username), md5((random()::text))));";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("is_super_user", is_super_user);
            command.Parameters.AddWithValue("email", email);



           command.Prepare();

            command.ExecuteNonQuery();

        }


    }
}
