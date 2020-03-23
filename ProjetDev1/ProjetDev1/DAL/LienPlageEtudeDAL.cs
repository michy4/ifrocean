using MySql.Data.MySqlClient;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAL
{
    class LienPlageEtudeDAL
    {
        private static MySqlConnection connection;
        public LienPlageEtudeDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<LienPlageEtudeDAO> selectPlageEtude()
        {
            ObservableCollection<LienPlageEtudeDAO> l = new ObservableCollection<LienPlageEtudeDAO>();
            string query = "SELECT * FROM LienPlageEtude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LienPlageEtudeDAO p = new LienPlageEtudeDAO(reader.GetInt32(0), reader.GetInt32(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updatePlageEtude(LienPlageEtudeDAO p)
        {
            string query = "UPDATE personne set Plage_idPlage=\"" + p.idplage + "\", Etude_idEtude=\"" + p.idetude + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlageEtudeDAO(LienPlageEtudeDAO p)
        {
            int id = getMaxIdLienPlageEtude() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.idplage + "\"" + p.idetude + "\";";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerLienPlageEtude(int idetude, int idplage)
        {
            string query = "DELETE FROM personne WHERE idPersonne = " + idetude + " AND Plage_idPlage="+ idplage + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdLienPlageEtude()
        {
            string query = "SELECT MAX(idPersonne) FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdPersonne = reader.GetInt32(0);
            reader.Close();
            return maxIdPersonne;
        }

        public static LienPlageEtudeDAO getLienPlageEtude(int idLienPlageEtude)
        {
            string query = "SELECT * FROM personne WHERE id=" + idLienPlageEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LienPlageEtudeDAO pers = new LienPlageEtudeDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}
