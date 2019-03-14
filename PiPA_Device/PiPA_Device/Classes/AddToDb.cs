using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PiPA_Device.Classes
{
    public class AddToDb
    {
        public async Task<string> AddAsync(string task)
        {
            string connectionString = "Server=tcp:pipa-server.database.windows.net,1433;Initial Catalog=PiPA-Db;Persist Security Info=False;User ID=PiPAAdmin;Password=PiPA123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DateTime time = DateTime.Now;
            string queryString = $"INSERT INTO TasksTable (ListID, TaskName, Description, DateCreated, PlannedDateComplete, CompletedDate, IsComplete) VALUES('1', '{task}', '{task}', '{time}', '{time}', '{time}', 'false');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
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
    }
}
