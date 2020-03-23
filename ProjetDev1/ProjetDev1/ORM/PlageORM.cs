using ProjetDev1.Ctrl;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.ORM
{
    class PlageORM
    {
        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            //int idMetier = pDAO.idMetierPersonneDAO;
            //MetierViewModel m = MetierORM.getMetier(idMetier);
            PlageViewModel p = new PlageViewModel(pDAO.id, pDAO.nom, pDAO.departement, pDAO.commune, pDAO.superficie, pDAO.coord1long, pDAO.coord1larg, pDAO.coord2long, pDAO.coord2larg, pDAO.coord3long, pDAO.coord3larg, pDAO.coord4long, pDAO.coord4larg);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                //int idMetier = element.idMetierPersonneDAO;
                //MetierDAO m = MetierDAO.getMetier(idMetier);
                //MetierViewModel metier = new MetierViewModel(m.idMetierDAO, m.libMetierDAO);
                PlageViewModel p = new PlageViewModel(element.id, element.nom, element.departement, element.commune, element.superficie, element.coord1long, element.coord1larg, element.coord2long, element.coord2larg, element.coord3long, element.coord3larg, element.coord4long, element.coord4larg);
                l.Add(p);
            }
            return l;
        }
    }
}
