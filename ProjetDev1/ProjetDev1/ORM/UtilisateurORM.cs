using ProjetDev1.DAO;
using ProjetDev1.Vue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.ORM
{
    public class UtilisateurORM
    {
        public static UtilisateurViewModel getPersonne(int idPersonne)
        {
            UtilisateurDAO pDAO = UtilisateurDAO.getPersonne(idPersonne);
            //int idMetier = pDAO.idMetierPersonneDAO;
            //MetierViewModel m = MetierORM.getMetier(idMetier);
            UtilisateurViewModel p = new UtilisateurViewModel(pDAO.idPersonneDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO/*, m*/);
            return p;
        }

        public static ObservableCollection<UtilisateurViewModel> listePersonnes()
        {
            ObservableCollection<UtilisateurDAO> lDAO = UtilisateurDAO.listePersonnes();
            ObservableCollection<UtilisateurViewModel> l = new ObservableCollection<UtilisateurViewModel>();
            foreach (UtilisateurDAO element in lDAO)
            {
                //int idMetier = element.idMetierPersonneDAO;
                //MetierDAO m = MetierDAO.getMetier(idMetier);
                //MetierViewModel metier = new MetierViewModel(m.idMetierDAO, m.libMetierDAO);
                UtilisateurViewModel p = new UtilisateurViewModel(element.idPersonneDAO, element.nomPersonneDAO, element.prenomPersonneDAO/*, metier*/);
                l.Add(p);
            }
            return l;
        }
    }
}
