using ProjetDev1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetDev1.Ctrl
{
    class ComptageViewModel
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

        public ComptageViewModel() { }

        public ComptageViewModel(int id, int idEtude, int idPlage, DateTime date, int NbPersonnes, float Coord1Long, float Coord1Larg, float Coord2Long, float Coord2Larg, float Coord3Long, float Coord3Larg, float Coord4Long, float Coord4Larg)
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
        public int idComptageProperty
        {
            get { return id; }
        }

        public int idEtudeProperty
        {
            get { return idEtude; }
            set
            {
                OnPropertyChanged("idEtudeProperty");
            }

        }
        public int idPlageProperty
        {
            get { return idPlage; }
            set
            {
                OnPropertyChanged("idPlageProperty");
            }
        }

        public DateTime DateProperty
        {
            get { return date; }
            set
            {
                OnPropertyChanged("dateProperty");
            }
        }

        public int NbPersonnesProperty
        {
            get { return NbPersonnes; }
            set
            {
                OnPropertyChanged("NbPersonnesProperty");
            }

        }

        public float Coord1LongProperty
        {
            get { return Coord1Long; }
            set
            {
                OnPropertyChanged("Coord1LongProperty");
            }
        }
        public float Coord1LargProperty
        {
            get { return Coord1Larg; }
            set
            {
                OnPropertyChanged("Coord1LargProperty");
            }
        }
        public float Coord2LongProperty
        {
            get { return Coord2Long; }
            set
            {
                OnPropertyChanged("Coord2LongProperty");
            }
        }
        public float Coord2LargProperty
        {
            get { return Coord2Larg; }
            set
            {
                OnPropertyChanged("Coord2LargProperty");
            }
        }
        public float Coord3LongProperty
        {
            get { return Coord3Long; }
            set
            {
                OnPropertyChanged("Coord3LongProperty");
            }
        }
        public float Coord3LargProperty
        {
            get { return Coord3Larg; }
            set
            {
                OnPropertyChanged("Coord3LargProperty");
            }
        }
        public float Coord4LongProperty
        {
            get { return Coord4Long; }
            set
            {
                OnPropertyChanged("Coord4LongProperty");
            }
        }
        public float Coord4LargProperty
        {
            get { return Coord4Larg; }
            set
            {
                OnPropertyChanged("Coord4LargProperty");
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
                ComptageDAO.updateComptage(this);
            }
        }
    }//ComptageProperty
}
