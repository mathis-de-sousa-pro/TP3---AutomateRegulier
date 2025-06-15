using AutomateRegulier.Modele.Algorithme.Automates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme
{
    public abstract class Algorithme
    {
        /// <summary>
        /// Liste des étapes
        /// </summary>
        public List<Etape> Etapes => etapes;
        private List<Etape> etapes;

        //Automate
        protected Automate? Automate
        {
            get => this.automate;
            set
            {
                if (this.automate != null) this.automate.PropertyChanged -= this.Automate_PropertyChanged;
                this.automate = value;
                if (this.automate != null) this.automate.PropertyChanged += this.Automate_PropertyChanged;
            }
        }
        private Automate? automate;


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Algorithme()
        {
            this.automate = null;
            this.etapes = new List<Etape>();
        }

        /// <summary>
        /// Ajoute automatique une étape à la liste lors d'un changement d'état de l'automate
        /// </summary>
        /// <param name="sender">L'automate</param>
        /// <param name="e">La modification de la propriété</param>
        protected void Automate_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(this.automate != null) this.etapes.Add(this.automate.EtapeTransition);
        }

        /// <summary>
        /// Retourne si le mot est valide ou non
        /// </summary>
        /// <param name="mot">Le mot à tester</param>
        /// <returns>Le résultat du test</returns>
        public bool EstValide(Mot mot)
        {
            if (this.automate != null) this.Etapes.Add(this.automate.EtapeTransition);
            return this.EstValide(new MotLisibleLettreALettre(mot));
        }

        /// <summary>
        /// Retourne si le mot est valide ou non
        /// </summary>
        /// <param name="mot">Le mot (lisible lettre à lettre</param>
        /// <returns>Le résultat du test</returns>
        protected bool EstValide(MotLisibleLettreALettre mot)
        {
            bool res = false;
            if (this.Automate != null) res = this.Automate.EstValide(mot);
            return res;
        }

    }
}
