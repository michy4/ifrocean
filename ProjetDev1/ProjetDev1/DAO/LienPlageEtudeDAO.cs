using ProjetDev1.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetDev1.DAO
{
    class LienPlageEtudeDAO
    {
        public int idplage { get; set; }
        public int idetude { get; set; }
        public LienPlageEtudeDAO(int idplage, int idetude)
        {
            this.idplage = idplage;
            this.idetude = idetude;
        }

        public static ObservableCollection<LienPlageEtudeDAO> listeEspeces()
        {
            ObservableCollection<LienPlageEtudeDAO> l = LienPlageEtudeDAL.selectPlageEtude();
            return l;
        }

        public static LienPlageEtudeDAO getLienPlageEtude(int idEspece)
        {
            LienPlageEtudeDAO p = LienPlageEtudeDAL.getLienPlageEtude(idEspece);
            return p;
        }
    }
}
