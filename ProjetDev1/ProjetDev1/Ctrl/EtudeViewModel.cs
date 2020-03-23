using ProjetDev1.DAO;
using ProjetDev1.Vue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetDev1.Ctrl
{
    public class EtudeViewModel
    {
        private int id;
        private string nom;
        private DateTime date;
        private UtilisateurViewModel proprio;
        //public MetierViewModel metierPersonne;

        public EtudeViewModel() { }

        public EtudeViewModel(int id, string nom, DateTime date, UtilisateurViewModel proprio/*, MetierViewModel metier*/)
        {
            this.id = id;
            this.nom = nom;
            this.date = date;
            this.proprio = proprio;
            //metierPersonne = metier;
        }
        public int idEtudeProperty
        {
            get { return id; }
            set
            {
                OnPropertyChanged("proprioEtudeProperty");
            }
        }

        public UtilisateurViewModel proprioEtudeProperty
        {
            get { return proprio; }
            set
            {
                OnPropertyChanged("proprioEtudeProperty");
            }
        }

        public String nomEtudeProperty
        {
            get { return nom; }
            set
            {
                nom = value.ToUpper();
                /*this.concatProperty = value.ToUpper() + " " + prenomPersonne;*/
                OnPropertyChanged("nomEtudeProperty");
            }

        }
        public DateTime dateEtudeProperty
        {
            get { return date; }
            set
            {
                /*this.prenomPersonne = value;
                this.concatProperty = this.nomPersonne + " " + value;*/
                OnPropertyChanged("dateEtudeProperty");
            }
        }

        /*public String concatProperty
        {
            get { return concat; }
            set
            {
                this.concat = "Ajouter " + value;
            }
        }*/

        /*public MetierViewModel MetierPersonne
        {
            get { return metierPersonne; }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeDAO.updateEtude(this);
            }
        }
    }
}
