using AutomateRegulier.Modele.Algorithme.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Algorithme servant d'exemple
    /// </summary>
    public class AlgorithmeExemple : Algorithme
    {
        public AlgorithmeExemple()
        {
            //Création des états
            Etat etatInitial = new Etat("Etat Initial");
            Etat etatAlu = new Etat("Etat A a été lu");

            //On définit les états terminaux
            etatAlu.EstTerminal = true;

            //Création de l'automate
            this.Automate = new Automate(etatInitial);

            //Définition des règles
            etatInitial.AddTransition('A', etatAlu);
            etatAlu.EtatParDefaut = etatAlu;
        }
    }
}
