using AnthonyscheeresApi.Dao;
using System.Security.Authentication;

namespace AnthonyscheeresApi.Services
{
     internal class TokenService
    {
        private readonly TokenDao tokenDao = new TokenDao();


       internal TokenService()
        {

        }


        /**
    * @author Anthony Scheeres
    */
        internal void getPermissionFromDatabaseByTokenIsAdmin(string token)
        {
            getPermissionFromDatabaseByTokenIsAdmin1(token);

        }


 



        /**
    * @author Anthony Scheeres
    */
       internal void getPermissionFromDatabaseByTokenIsAdmin1(string token)
        {
            //default response
            bool response = false;



            response = tokenDao.getPermissionFromDatabaseByTokenHasAdmin(token);

            if (response != true) throw new AuthenticationException();

        }




        internal double TokenToUserId(string token)
        {
            return TokenToUserId2(token);
        }






        /**
* @author Anthony Scheeres
*/
        private double TokenToUserId2(string token)
        {
            return tokenDao.TokenToUserIdThrowsException(token);
        }

    }
}






