using MySql.Data.MySqlClient;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAL
{
    public class EspeceDAL
    {
        private static MySqlConnection connection;

        public EspeceDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            string query = "SELECT * FROM Espece WHERE idEspece=" + idEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceDAO met = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return met;
        }
        public static void updateEspece(int idEspece, string libEspece)
        {
            string query = "UPDATE metier set libMetier=\"" + libEspece + "\" where idMetier=" + idEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static ObservableCollection<EspeceDAO> selectEspeces()
        {
            ObservableCollection<EspeceDAO> l = new ObservableCollection<EspeceDAO>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EspeceDAO p = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static EspeceDAO getPersonne(int idEspece)
        {
            string query = "SELECT * FROM personne WHERE idEspece=" + idEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceDAO pers = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }
    }
}
