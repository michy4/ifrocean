using ProjetDev1.Ctrl;
using ProjetDev1.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAO
{
    public class EtudeDAO
    {
        public int id { get; set; }
        public string nom { get; set; }
        public DateTime date { get; set; }
        public int proprio { get; set; }
        public EtudeDAO(int id, string nom, DateTime date, int proprio)
        {
            this.id = id;
            this.nom = nom;
            this.date = date;
            this.proprio = proprio;
        }

        public static ObservableCollection<EtudeDAO> listeEtudes()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtude();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO p = EtudeDAL.getEtude(idEtude);
            return p;
        }

        public static void updateEtude(EtudeViewModel p)
        {
            EtudeDAL.updateEtude(p.idEtudeProperty, p.nomEtudeProperty);
        }
    }
}
