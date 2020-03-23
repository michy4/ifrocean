using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev1.Ctrl
{
    public class EspeceViewModel
    {
        public int id { get; set; }
        public string nom { get; set; }
        public EspeceViewModel() { }

        public EspeceViewModel(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
            //metierPersonne = metier;
        }
    }
}