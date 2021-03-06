﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyscheeresApi.Utilities
{
     internal static class PsqlUtilities
    {


/*
 *This methode doesn't seem to work with less rows than 2
 * 
             */
         internal static object GetString(this NpgsqlDataReader source, string colname)
        {
            if (string.IsNullOrEmpty(colname))
                throw new ArgumentNullException();

            return source.GetString(source.GetOrdinal(colname));
        }

         internal static List<object[]> GetAll(NpgsqlDataReader reader)
        {
           

            List<object[]> result = new List<object[]>();
            using (var dataReader = reader)
            {
                while (dataReader.Read())
                {
                    var values = new object[dataReader.FieldCount];
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        values[i] = dataReader[i];
                    }
                    result.Add(values);
                }
            }

            return result;
        }
    }
}
