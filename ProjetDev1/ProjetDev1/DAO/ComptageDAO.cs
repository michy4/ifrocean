using ProjetDev1.Ctrl;
using ProjetDev1.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAO
{
    class ComptageDAO
    {
        public int id;
        public int idEtude;
        public int idPlage;
        public DateTime date;
        public int NbPersonnes;
        public float Coord1Long;
        public float Coord1Larg;
        public float Coord2Long;
        public float Coord2Larg;
        public float Coord3Long;
        public float Coord3Larg;
        public float Coord4Long;
        public float Coord4Larg;


        public ComptageDAO(int id, int idEtude, int idPlage, DateTime date, int NbPersonnes, float Coord1Long, float Coord1Larg, float Coord2Long, float Coord2Larg, float Coord3Long, float Coord3Larg, float Coord4Long, float Coord4Larg)
        {
            this.id = id;
            this.idEtude = idEtude;
            this.idPlage = idPlage;
            this.date = date;
            this.NbPersonnes = NbPersonnes;
            this.Coord1Long = Coord1Long;
            this.Coord1Larg = Coord1Larg;
            this.Coord2Long = Coord2Long;
            this.Coord2Larg = Coord2Larg;
            this.Coord3Long = Coord3Long;
            this.Coord3Larg = Coord3Larg;
            this.Coord4Long = Coord4Long;
            this.Coord4Larg = Coord4Larg;
        }

        public static ObservableCollection<ComptageDAO> listeComptages()
        {
            ObservableCollection<ComptageDAO> l = ComptageDAL.selectComptages();
            return l;
        }

        public static ComptageDAO getComptage(int idPersonne)
        {
            ComptageDAO p = ComptageDAL.getComptage(idPersonne);
            return p;
        }

        public static void updateComptage(ComptageViewModel p)
        {
            ComptageDAL.updateComptage(new ComptageDAO(p.id, p.idEtude, p.idPlage, p.date, p.NbPersonnes, p.Coord1Long, p.Coord1Larg, p.Coord2Long, p.Coord2Larg, p.Coord3Long, p.Coord3Larg, p.Coord4Long, p.Coord4Larg));
        }

        public static void supprimerComptage(int id)
        {
            ComptageDAL.supprimerComptage(id);
        }

        public static void insertComptage(ComptageViewModel p)
        {
            ComptageDAL.insertComptage(new ComptageDAO(p.id, p.idEtude, p.idPlage, p.date, p.NbPersonnes, p.Coord1Long, p.Coord1Larg, p.Coord2Long, p.Coord2Larg, p.Coord3Long, p.Coord3Larg, p.Coord4Long, p.Coord4Larg));
        }
    }
}
