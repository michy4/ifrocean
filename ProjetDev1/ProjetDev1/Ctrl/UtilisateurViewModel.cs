using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetDev1.Vue
{
    public class UtilisateurViewModel
    {
        public int idPersonne;
        public string nomPersonne;
        public string prenomPersonne;
        public string concat;
        //public MetierViewModel metierPersonne;

        public UtilisateurViewModel() { }

        public UtilisateurViewModel(int id, string nom, string prenom/*, MetierViewModel metier*/)
        {
            this.idPersonne = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            //metierPersonne = metier;
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
        }

        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value.ToUpper();
                this.concatProperty = value.ToUpper() + " " + prenomPersonne;
                OnPropertyChanged("nomPersonneProperty");
            }

        }
        public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
                this.concatProperty = this.nomPersonne + " " + value;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }

        public String concatProperty
        {
            get { return concat; }
            set
            {
                this.concat = "Ajouter " + value;
            }
        }

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
                UtilisateurDAO.updatePersonne(this);
            }
        }
    }
}
