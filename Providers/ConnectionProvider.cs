using AnthonyscheeresApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anthonyscheeresApi.Providers
{
     internal static class ConnectionProvider
    {
        
        private static NpgsqlConnection npgsqlConnection { set; get; }
       
        
         internal static NpgsqlConnection getProvide()
        {
            if (npgsqlConnection ==null)
            {
                string cs = DataModel.getConfigModel().databaseCredentials.cs;
                npgsqlConnection = ConnectionProvider.getProvide();

            }
            return npgsqlConnection;
        }

    }
}
