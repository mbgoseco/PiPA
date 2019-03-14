using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PiPA_Device.Classes
{
    public class AddToDb
    {
        string connectionString = "Server=tcp:pipa-server.database.windows.net,1433;Initial Catalog=PiPA-Db;Persist Security Info=False;User ID=PiPAAdmin;Password=PiPA123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<string> AddAsync(string task)
        {
            DateTime time = DateTime.Now;
            string queryStringInsert = $"INSERT INTO TasksTable (ListID, TaskName, Description, DateCreated, PlannedDateComplete, CompletedDate, IsComplete) VALUES('1', '{task}', '{task}', '{time}', '{time}', '{time}', 'false');";

            var userID = GetUserID();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringInsert, connection);
                connection.Open();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    return "name task";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "Error";
                }
            }
        }

        public async Task<int> GetUserID()
        {
            string queryStringGetUser = $"SELECT ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringGetUser, connection);
                connection.Open();
            }
        }
    }
}
