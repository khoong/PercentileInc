using Npgsql;
using System;
using System.Collections.Generic;


namespace WebApi.Models
{
    public class Percentile
    {
        public static IEnumerable<double> GetData()
        {
            string query = "SELECT * FROM public.get_data();";

            using (var conn = new NpgsqlConnection(Startup.ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return (double)reader[0];
                        }
                    }
                }
            }
        }
    }
}
