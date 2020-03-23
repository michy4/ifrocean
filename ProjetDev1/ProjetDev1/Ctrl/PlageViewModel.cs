using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev1.Ctrl
{
    class PlageViewModel
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string departement { get; set; }
        public string commune { get; set; }
        public float superficie { get; set; }
        public float coord1long { get; set; }
        public float coord1larg { get; set; }
        public float coord2long { get; set; }
        public float coord2larg { get; set; }
        public float coord3long { get; set; }
        public float coord3larg { get; set; }
        public float coord4long { get; set; }
        public float coord4larg { get; set; }

        public PlageViewModel(int id, string nom, string departement, string commune, float superficie, float c1lo, float c1la, float c2lo, float c2la, float c3lo, float c3la, float c4lo, float c4la)
        {
            this.id = id;
            this.nom = nom;
            this.departement = departement;
            this.commune = commune;
            this.superficie = superficie;
            this.coord1long = c1lo;
            this.coord1larg = c1la;
            this.coord2long = c2lo;
            this.coord2larg = c2la;
            this.coord3long = c3lo;
            this.coord3larg = c3la;
            this.coord4long = c4lo;
            this.coord4larg = c4la;
        }
    }
}
