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
            
            try
            {
                SqlTransaction transaction;
                SqlCommand cardCmd = _connection.CreateCommand();
                SqlCommand bankAccountCmd = _connection.CreateCommand();
                transaction = _connection.BeginTransaction("NewBankAccountTransaction");

                bankAccountCmd.Connection = _connection;
                bankAccountCmd.Transaction = transaction;

                cardCmd.Connection = _connection;
                cardCmd.Transaction = transaction;

                try
                {
                    decimal balance = 0.0m;

                    bankAccountCmd.CommandText = "INSERT INTO dbo.BankAccounts (accountNumber, username, pin, balance) " + "VALUES(@accountNumber, @username, @pin, @balance)";
                    bankAccountCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    bankAccountCmd.Parameters.AddWithValue("@username", username);
                    bankAccountCmd.Parameters.AddWithValue("@pin", pin);
                    bankAccountCmd.Parameters.AddWithValue("@balance", balance);
                    bankAccountCmd.ExecuteNonQuery();

                    int iter = 0;
                    StringBuilder cardNumber = new StringBuilder("");
                    do
                    {
                        int randomNumber = new Random().Next(1000, 9999);
                        if (iter != 3)
                        {
                            cardNumber.Append(randomNumber + "-");
                        }
                        else
                        {
                            cardNumber.Append(randomNumber);
                        }
                        iter++;
                    } while (iter != 4);

                    int cvv = new Random().Next(100, 999);

                    cardCmd.CommandText = "INSERT INTO dbo.BankCards (accountNumber, cardNumber, cardHolderName, expiration, cvv, cardType, maxLimit) " + "VALUES(@accountNumber, @cardNumber, @cardHolderName, @expiration, @cvv, @cardType, @maxLimit)";
                    cardCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cardCmd.Parameters.AddWithValue("@cardNumber", cardNumber.ToString());
                    cardCmd.Parameters.AddWithValue("@cardHolderName", username);
                    cardCmd.Parameters.AddWithValue("@expiration", DateTime.UtcNow.AddYears(7));
                    cardCmd.Parameters.AddWithValue("@cvv", cvv);
                    cardCmd.Parameters.AddWithValue("@cardType", "Debit");
                    cardCmd.Parameters.AddWithValue("@maxLimit", 99999999999999);
                    cardCmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Records written to DB.");
                } catch (Exception ex)
                {
                    Console.WriteLine("CreateAccount() Exception during transaction. {0}", ex.Message);
                    Console.WriteLine("Exception type: {0}", ex.GetType());
                    Console.WriteLine("Attempting rollback");

                    try
                    {
                        transaction.Rollback();
                    } catch (Exception rollbackException)
                    {
                        Console.WriteLine("Rollback exception failed: {0}", rollbackException.Message);
                        Console.WriteLine("Rollback exception type: {0}", rollbackException.GetType());
                    }
                }             
                return 1;
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