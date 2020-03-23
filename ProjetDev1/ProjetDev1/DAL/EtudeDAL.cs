using MySql.Data.MySqlClient;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAL
{
    class EtudeDAL
    {
        private static MySqlConnection connection;

        public EtudeDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM Etude WHERE idEtude=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO met = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
            reader.Close();
            return met;
        }
        public static void updateEtude(int idEtude, string NomEtude)
        {
            string query = "UPDATE Etude set Nom=\"" + NomEtude + "\" where idEtude=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static ObservableCollection<EtudeDAO> selectEtude()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EtudeDAO p = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        /*public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM Etude WHERE id=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO pers = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), "John Doe");
            reader.Close();
            return pers;
        }*/
    }
}
