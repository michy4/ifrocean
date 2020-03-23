using ProjetDev1.DAL;
using ProjetDev1.Vue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAO
{
    public class UtilisateurDAO
    {
        public int idPersonneDAO;
        public string nomPersonneDAO;
        public string prenomPersonneDAO;
        public int idMetierPersonneDAO;

        public UtilisateurDAO(int idPersonneDAO, string nomPersonneDAO, string prenomPersonneDAO/*, int idMetierPersonneDAO*/)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.nomPersonneDAO = nomPersonneDAO;
            this.prenomPersonneDAO = prenomPersonneDAO;
            //this.idMetierPersonneDAO = idMetierPersonneDAO;
        }

        public static ObservableCollection<UtilisateurDAO> listePersonnes()
        {
            ObservableCollection<UtilisateurDAO> l = UtilisateurDAL.selectPersonnes();
            return l;
        }

        public static UtilisateurDAO getPersonne(int idPersonne)
        {
            UtilisateurDAO p = UtilisateurDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(UtilisateurViewModel p)
        {
            UtilisateurDAL.updatePersonne(new UtilisateurDAO(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty/*, p.metierPersonne.idMetier*/));
        }

        public static void supprimerPersonne(int id)
        {
            UtilisateurDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(UtilisateurViewModel p)
        {
            UtilisateurDAL.insertPersonne(new UtilisateurDAO(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty/*, p.metierPersonne.idMetier*/));
        }
    }
}
