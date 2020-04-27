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
        
        
     

        internal static NpgsqlConnection getProvide()
        {
            string cs = DataModel.getConfigModel().databaseCredentials.cs;
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(cs);

            return npgsqlConnection;
        }

    }
}
