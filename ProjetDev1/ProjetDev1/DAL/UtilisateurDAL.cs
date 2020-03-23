using MySql.Data.MySqlClient;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAL
{
    public class UtilisateurDAL
    {
        private static MySqlConnection connection;
        public UtilisateurDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<UtilisateurDAO> selectPersonnes()
        {
            ObservableCollection<UtilisateurDAO> l = new ObservableCollection<UtilisateurDAO>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UtilisateurDAO p = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)/*, reader.GetInt32(3)*/);
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updatePersonne(UtilisateurDAO p)
        {
            string query = "UPDATE personne set nomPersonne=\"" + p.nomPersonneDAO + "\", prenomPersonne=\"" + p.prenomPersonneDAO + "\", idMetier=\"" + p.idMetierPersonneDAO + "\" where idPersonne=" + p.idPersonneDAO + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonne(UtilisateurDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.nomPersonneDAO + "\",\"" + p.prenomPersonneDAO + "\",\"" + p.idMetierPersonneDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPersonne()
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

        public static UtilisateurDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE idPersonne =" + idPersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UtilisateurDAO pers = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)/*, reader.GetInt32(3)*/);
            reader.Close();
            return pers;
        }
    }
}
