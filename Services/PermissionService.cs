﻿using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{

    /**
* @author Anthony Scheeres
*/
    internal class PermissionService
    {
        private readonly PermissionDao permissionDao = new PermissionDao();


        /**
* @author Anthony Scheeres
*/
        internal string loginUserAfterValidation(string username, string password)
        {
            return validateLoginUser(username, password);
        }


        internal string loginUserAfterValidation(UserModel user)
        {
            return loginUserAfterValidation(user.username, user.password);
        }

        /**
* @author Anthony Scheeres
*/
        private string validateLoginUser(string username, string password)
        {
            //filter invalide input here if needed
            return loginUser(username, password);




        }

        /**
* @author Anthony Scheeres
*/
        private string loginUser(string username, string password)
        {
            //response fail message

            string failResponse = ResponseR.fail.ToString();

            string response = failResponse;
            bool hasCorrectCrecdentials = false;

            try
            {
                //check if username and password combo exist only works if usernames stay unique
                hasCorrectCrecdentials = permissionDao.checkUsernameAndPassword(username, password);

            }
            catch (InvalidOperationException error)
            {
                //return the reponse so the unauthorised user doesn't get a token
                return response;
            }

            if (hasCorrectCrecdentials)
            {
                string successfulResponse = ResponseR.success.ToString(); response = successfulResponse;

                response = permissionDao.getSensitiveUserInfoFromDatabaseByUsername(username);
            }


            return response;
        }



    }
}
