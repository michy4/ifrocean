using ProjetDev1.Ctrl;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.ORM
{
    class ComptageORM
    {
        public static ComptageViewModel getComptage(int idPersonne)
        {
            ComptageDAO pDAO = ComptageDAO.getComptage(idPersonne);
            //int idMetier = pDAO.idMetierPersonneDAO;
            //MetierViewModel m = MetierORM.getMetier(idMetier);
            ComptageViewModel p = new ComptageViewModel(pDAO.id, pDAO.idEtude, pDAO.idPlage, pDAO.date, pDAO.NbPersonnes, pDAO.Coord1Long, pDAO.Coord1Larg, pDAO.Coord2Long, pDAO.Coord2Larg, pDAO.Coord3Long, pDAO.Coord3Larg, pDAO.Coord4Long, pDAO.Coord4Larg);
            return p;
        }

        public static ObservableCollection<ComptageViewModel> listeComptages()
        {
            ObservableCollection<ComptageDAO> lDAO = ComptageDAO.listeComptages();
            ObservableCollection<ComptageViewModel> l = new ObservableCollection<ComptageViewModel>();
            foreach (ComptageDAO element in lDAO)
            {
                //int idMetier = element.idMetierPersonneDAO;
                //MetierDAO m = MetierDAO.getMetier(idMetier);
                //MetierViewModel metier = new MetierViewModel(m.idMetierDAO, m.libMetierDAO);
                ComptageViewModel p = new ComptageViewModel(element.id, element.idEtude, element.idPlage, element.date, element.NbPersonnes, element.Coord1Long, element.Coord1Larg, element.Coord2Long, element.Coord2Larg, element.Coord3Long, element.Coord3Larg, element.Coord4Long, element.Coord4Larg);
                l.Add(p);
            }
            return l;
        }
    }
}
