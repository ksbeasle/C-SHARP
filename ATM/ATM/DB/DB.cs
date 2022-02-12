using ATM.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ATM.DB
{
    public class DB
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


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static int CreateAccount(Guid accountNumber, string username, string pin)
        {
            decimal balance = 0.0m;
            try
            {
                // TODO finish transaction for both tables
                SqlTransaction transaction;
                transaction = _connection.BeginTransaction("NewBankAccountTransaction");

                SqlCommand bankaccountInsert = new SqlCommand("INSERT INTO dbo.BankAccounts (accountNumber, username, pin, balance) " + "VALUES(@accountNumber, @username, @pin, @balance)", _connection);

                // Add the parameters for the InsertCommand.
                bankaccountInsert.Parameters.AddWithValue("@accountNumber", accountNumber);
                bankaccountInsert.Parameters.AddWithValue("@username", username);
                bankaccountInsert.Parameters.AddWithValue("@pin", pin);
                bankaccountInsert.Parameters.AddWithValue("@balance", balance);

                var bankAccountRes = bankaccountInsert.ExecuteNonQuery();

                int iter = 0;
                StringBuilder sb = new StringBuilder("");
                do
                {
                    int randomNumber = new Random().Next(1000, 9999);
                    if(iter != 3)
                    {
                        sb.Append(randomNumber + "-");
                    }else
                    {
                        sb.Append(randomNumber);
                    }
                    iter++;
                } while (iter != 4);
                return 1;
                //SqlCommand newCard = new SqlCommand("INSERT INTO dbo.BankCards () " + "VALUES()");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error executing query: {e.Message}");
                return -1;
            }
        }

        public static BankAccountEntity GetAccount(string username, string pin)
        {
            return null;
        }

        public static void Query(string stmt)
        {
            try
            {
                SqlCommand command = new SqlCommand(stmt, _connection);
                var results = command.ExecuteReader();
                while (results.Read())
                {
                    Console.WriteLine(results.GetInt32(0));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error executing query: {e.Message}");
            }
        }


    }
}