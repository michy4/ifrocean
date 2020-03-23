using ProjetDev1.Ctrl;
using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.ORM
{
    public class EspeceORM
    {
        public static EspeceViewModel getEspece(int idEspece)
        {
            EspeceDAO pDAO = EspeceDAO.getEspece(idEspece);
            EspeceViewModel p = new EspeceViewModel(pDAO.id, pDAO.nom);
            return p;
        }

        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<EspeceDAO> lDAO = EspeceDAO.listeEspeces();
            ObservableCollection<EspeceViewModel> l = new ObservableCollection<EspeceViewModel>();
            foreach (EspeceDAO element in lDAO)
            {
                EspeceViewModel p = new EspeceViewModel(element.id, element.nom);
                l.Add(p);
            }
            return l;
        }
    }
}
