using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ATM.DB
{
    public class DBConnection
    {
           public static bool InitDB()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            var section = config.GetSection(nameof(ConnectionStrings));
            var weatherClientConfig = section.Get<ConnectionStrings>();
            // TODO - finish connection to DB
            SqlConnection connection = new SqlConnection();
            return true;
        }
    }
}
