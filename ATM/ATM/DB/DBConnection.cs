using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ATM.DB
{
    public class DBConnection
    {
        private static SqlConnection? _connection;
        
        public static bool InitDB()
        {

            try
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
                var section = config.GetSection("ConnectionStrings");
                string dbString = section.GetValue<string>("AtmDB");

                _connection = new SqlConnection(dbString);
                _connection.Open();
                return true;

                
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }      
        }

        public static void Query(string stmt)
        {
            try
            {
                SqlCommand command = new SqlCommand(stmt, _connection);
                var results = command.ExecuteReader();
                if (results.HasRows)
                {
                    foreach (DataRow row in results.GetSchemaTable().Rows)
                    {
                        Console.WriteLine("ROW", row);
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine($"Error executing query: {e.Message}");
            }
        }


    }
}