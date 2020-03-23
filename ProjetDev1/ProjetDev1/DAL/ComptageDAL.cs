using MySql.Data.MySqlClient;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAL
{
    class ComptageDAL
    {
        private static MySqlConnection connection;
        public ComptageDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<ComptageDAO> selectComptages()
        {
            ObservableCollection<ComptageDAO> l = new ObservableCollection<ComptageDAO>();
            string query = "SELECT * FROM comptage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ComptageDAO p = new ComptageDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateComptage(ComptageDAO p)
        {
            string query = "UPDATE comptage set idEtude=\"" + p.idEtude + "\", idPlage=\"" + p.idPlage + "\", date=\"" + p.date + "\", NbPersonnes=\"" + p.NbPersonnes + "\", Coord1Long=\"" + p.Coord1Long + "\", Coord1Larg=\"" + p.Coord1Larg + "\", Coord2Long=\"" + p.Coord2Long + "\", Coord2Larg=\"" + p.Coord2Larg + "\", Coord3Long=\"" + p.Coord3Long + "\", Coord3Larg=\"" + p.Coord3Larg + "\", Coord4Long=\"" + p.Coord4Long + "\", Coord4Larg=\"" + p.Coord4Larg + "\" where idComptage=" + p.id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertComptage(ComptageDAO p)
        {
            int id = getMaxIdComptage() + 1;
            string query = "INSERT INTO comptage VALUES (\"" + id + "\",\"" + p.idEtude + "\",\"" + p.idPlage + "\",\"" + p.date + "\",\"" + p.NbPersonnes + "\",\"" + p.Coord1Long + "\",\"" + p.Coord1Larg + "\",\"" + p.Coord2Long + "\",\"" + p.Coord2Larg + "\",\"" + p.Coord3Long + "\",\"" + p.Coord3Larg + "\",\"" + p.Coord4Long + "\",\"" + p.Coord4Larg + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerComptage(int id)
        {
            string query = "DELETE FROM comptage WHERE idComptage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdComptage()
        {
            string query = "SELECT MAX(idComptage) FROM Comptage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdComptage = reader.GetInt32(0);
            reader.Close();
            return maxIdComptage;
        }

        public static ComptageDAO getComptage(int idComptage)
        {
            string query = "SELECT * FROM Comptage WHERE idComptage=" + idComptage + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ComptageDAO pers = new ComptageDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12)/*, reader.GetInt32(3)*/);
            reader.Close();
            return pers;
        }
    }
}
