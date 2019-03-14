using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PiPA_Device.Classes
{
    public class AddToDb
    {
        string ListConnectionString = "Server=tcp:pipa-server.database.windows.net,1433;Initial Catalog=PiPA-Db;Persist Security Info=False;User ID=PiPAAdmin;Password=PiPA123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string UserConnectionString = "Server=tcp:pipa-server.database.windows.net,1433;Initial Catalog=PiPA-UserDb;Persist Security Info=False;User ID=PiPAAdmin;Password=PiPA123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<string> AddAsync(string task)
        {
            string userID = await GetUserID();
            if (userID == "Error")
            {
                return userID;
            }

            DateTime time = DateTime.Now;
            string queryStringInsert = $"INSERT INTO TasksTable (ListID, TaskName, Description, DateCreated, PlannedDateComplete, CompletedDate, IsComplete) VALUES('{Convert.ToInt32(userID)}', '{task}', '{task}', '{time}', '{time}', '{time}', 'false');";

            using (SqlConnection connection = new SqlConnection(ListConnectionString))
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

        public async Task<string> GetUserID()
        {
            string userName = "";
            string userID = "";
            string queryStringGetUser = $"SELECT UserName FROM AspNetUsers WHERE LoggedIn = true;";

            using (SqlConnection connection = new SqlConnection(UserConnectionString))
            {
                SqlCommand command = new SqlCommand(queryStringGetUser, connection);
                connection.Open();

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var tableRow = (IDataRecord)reader;
                        userName = tableRow[1].ToString();
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "Error";
                }
            }

            string queryStringGetUserID = $"SELECT ID FROM ListsTable WHERE UserID = '{userName}';";

            using (SqlConnection connection = new SqlConnection(ListConnectionString))
            {
                SqlCommand command = new SqlCommand(queryStringGetUserID, connection);
                connection.Open();

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var tableRow = (IDataRecord)reader;
                        userID = tableRow[0].ToString();
                    }

                    reader.Close();
                    return userID;
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
