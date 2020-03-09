﻿using ChantemerleApi.Models;
using Npgsql;
using Newtonsoft.Json;
using ChantemerleApi.Utilities;

namespace ChantemerleApi.Dao
{
    public class PermissionDao
    {
        private readonly DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        private string cs = DataModel.getConfigModel().databaseCredentials.cs;

        internal PermissionDao(string cs)
        {
            this.cs = cs;
        }



        internal PermissionDao()
        {
        }

        internal bool checkUsernameAndPassword(string username, string password)
        {
            const string sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE username = @username AND password = @password)";


           
            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Parameters.AddWithValue("password", password);





            command.Prepare();

            var i = command.ExecuteReader();
            bool credentialsAreValid = i.GetBoolean(1);
            connectionWithDatabase.Close();
            return credentialsAreValid;


        }


        internal bool checkUsernameAndToken(string username, string token)
        {
            const string sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE token = @token AND username = @username)";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Parameters.AddWithValue("token", token);





            command.Prepare();

            var i = command.ExecuteReader();
            bool areTheseCredentialsValid = i.GetBoolean(1);
            connectionWithDatabase.Close();
            return areTheseCredentialsValid;


        }



        internal string getSensitiveUserInfoFromDatabaseByUsername(string username)
        {

            const string sqlQueryForLoginUser = "update app_users set token = oncat(md5(@username), md5((random()::text))) where username = @username  ; select is_super_user, username, token, is_email_verified from app_users where username=@username;";

            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
        }



    }
}
