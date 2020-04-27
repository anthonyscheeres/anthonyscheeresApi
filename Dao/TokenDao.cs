﻿using anthonyscheeresApi.Providers;
using AnthonyscheeresApi.Models;
using AnthonyscheeresApi.Utilities;
using Npgsql;
using System;

namespace AnthonyscheeresApi.Dao
{
     internal class TokenDao
    {
        



        /**
   * @author Anthony Scheeres
   */
  


        /**
   * @author Anthony Scheeres
   */
         internal TokenDao()
        {
        }


        /**
   * @author Anthony Scheeres
   */
        internal bool getPermissionFromDatabaseByTokenHasAdmin(string token)
        {

            var sqlQueryForRegistingUser = "select is_super_user from app_users where token= @token";

            using var connectionWithDatabase = ConnectionProvider.getProvide();

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            bool areTheseCredentialsValid= false;
            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (r.GetValue(0).ToString().ToLower() == "true") areTheseCredentialsValid = true; });
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return areTheseCredentialsValid;

        }


        internal string getTokenByUsernameExtremelyClassified(string username)
        {

            var sqlQueryForRegistingUser = "select token from app_users where username = @username";

            using var connectionWithDatabase = ConnectionProvider.getProvide();

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            string hasAdmin = "";
            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (r.GetValue(0).ToString().Length >= 1) hasAdmin = r.GetValue(0).ToString(); });
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return hasAdmin;
        }



        internal string getTokenByUsernameExtremelyClassified(double id)
        {

            var sqlQueryForRegistingUser = "select token from app_users where id = @id";

            using var connectionWithDatabase = ConnectionProvider.getProvide();

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("id", id);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();

            string hasAdmin = "";

            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (r.GetValue(0).ToString().Length >= 1) hasAdmin = r.GetValue(0).ToString(); });
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return hasAdmin;
        }


        private double TokenToUserIdn(string token)
        {
            var sqlQueryForRegistingUser = "select id from app_users where token=@token";

            using var connectionWithDatabase = ConnectionProvider.getProvide();

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            int id = 0;
            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (ValidateInputUtilities.isNumeric(r.GetValue(0).ToString())) id = int.Parse(r.GetValue(0).ToString()); });
         

            connectionWithDatabase.Close(); //close the connection to save bandwith
            return id;

        }
        internal double TokenToUserIdThrowsException(string token)
        {
            double id = TokenToUserIdn(token);


            if (id == 0) { throw new ArgumentNullException(); }

      
            return id;

        }


    }
}
