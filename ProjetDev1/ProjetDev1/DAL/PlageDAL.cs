using MySql.Data.MySqlClient;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAL
{
    class PlageDAL
    {
        private static MySqlConnection connection;

        public PlageDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            string query = "SELECT * FROM Plage WHERE idPlage=" + idPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PlageDAO met = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetFloat(5), reader.GetFloat(6), reader.GetFloat(7), reader.GetFloat(8), reader.GetFloat(9), reader.GetFloat(10), reader.GetFloat(11), reader.GetFloat(12));
            reader.Close();
            return met;
        }
        public static void updatePlage(int idEtude, string NomEtude)
        {
            string query = "UPDATE Etude set Nom=\"" + NomEtude + "\" where idEtude=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static ObservableCollection<PlageDAO> selectPlage()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM Plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PlageDAO p = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetFloat(5), reader.GetFloat(6), reader.GetFloat(7), reader.GetFloat(8), reader.GetFloat(9), reader.GetFloat(10), reader.GetFloat(11), reader.GetFloat(12));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
    }
}
