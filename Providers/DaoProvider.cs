﻿
using AnthonyscheeresApi.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anthonyscheeresApi.Providers
{

     internal static class DaoProvider
    {
       private static ContactInfoDao contactInfoDao { get; set; }
        private static PermissionDao permissionDao { get; set; }
        private static TokenDao tokenDao { get; set; }
        private static UserDao userDao { get; set; }

         internal static ContactInfoDao getContact()
        {
            if (contactInfoDao ==null)
            {
                contactInfoDao = new ContactInfoDao();
            }
            return contactInfoDao;
        }

         internal static PermissionDao getPermission()
        {
            if (permissionDao ==null)
            {
                permissionDao = new PermissionDao();
            }
            return permissionDao;
        }


         internal static TokenDao getToken()
        {
            if (tokenDao ==null)
            {
                tokenDao = new TokenDao();
            }
            return tokenDao;
        }

         internal static UserDao getUser()
        {
            if (userDao == null)
            {
                userDao = new UserDao();
            }
            return userDao;

        }




    }
}
