using MySql.Data.MySqlClient;
using ProjetDev1.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAO
{
    public class EspeceDAO
    {
        public int id { get; set; }
        public string nom { get; set; }
        public EspeceDAO(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public static ObservableCollection<EspeceDAO> listeEspeces()
        {
            ObservableCollection<EspeceDAO> l = EspeceDAL.selectEspeces();
            return l;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO p = EspeceDAL.getEspece(idEspece);
            return p;
        }

    }
}
