using ProjetDev1.Ctrl;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.ORM
{
    class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO pDAO = EtudeDAO.getEtude(idEtude);
            //int idMetier = pDAO.idMetierPersonneDAO;
            //MetierViewModel m = MetierORM.getMetier(idMetier);
            EtudeViewModel p = new EtudeViewModel(pDAO.id, pDAO.nom, pDAO.date, UtilisateurORM.getPersonne(pDAO.proprio)/*, m*/);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                //int idMetier = element.idMetierPersonneDAO;
                //MetierDAO m = MetierDAO.getMetier(idMetier);
                //MetierViewModel metier = new MetierViewModel(m.idMetierDAO, m.libMetierDAO);
                EtudeViewModel p = new EtudeViewModel(element.id, element.nom, element.date, UtilisateurORM.getPersonne(element.proprio)/*, metier*/);
                l.Add(p);
            }
            return l;
        }
    }
}
