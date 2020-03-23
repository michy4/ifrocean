using System;
using MySql.Data.MySqlClient;

namespace ProjetDev1.DAL
{
    public class DALConnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static Boolean OpenConnection()
        {

            if (connection == null)
            {
                server = "localhost";
                database = "mydb";
                uid = "root";
                password = "";
                string connectionString;
                connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password}";
                connection = new MySqlConnection(connectionString);
                connection.Open();

                return true;
            }
            return false;
        }
    }
}