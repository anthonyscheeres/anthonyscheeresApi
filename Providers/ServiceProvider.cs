using AnthonyscheeresApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anthonyscheeresApi.Providers
{
     internal static class ServiceProvider
    {

        private static ContactInfoService contactInfoService { get; set; }
        private static PermissionService permissionService { get; set; }
        private static TokenService tokenService { get; set; }
        private static UserService userService { get; set; }

         internal static ContactInfoService getContact()
        {
            if (contactInfoService == null)
            {
                contactInfoService = new ContactInfoService();
            }
            return contactInfoService;
        }

         internal static PermissionService GetPermission()
        {
            if (permissionService == null)
            {
                permissionService = new PermissionService();
            }
            return permissionService;
        }


         internal static TokenService getToken()
        {
            if (tokenService == null)
            {
                tokenService = new TokenService();
            }
            return tokenService;
        }

         internal static UserService getUser()
        {
            if (userService == null)
            {
                userService = new UserService();
            }
            return userService;

        }




    }
}
