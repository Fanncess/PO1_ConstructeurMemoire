using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO1_ConstructeurMemoire
{
    public class Joueur // la classe
    {
        private string nom; // attribut
        private Equipe equipe;

        public Joueur(string nom, Equipe equipe) // constructeur
        {
            Nom = nom;
            Equipe = equipe;
        }

        public string Nom { get => nom; set => nom = value; }
        public Equipe Equipe { get => equipe; set => equipe = value; } // encapsulation

        public override string ToString() 
        {
            return Nom + " des " + Equipe.Nom;
        }
        
       
    }
}
