using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Automates
{
    public class Automate : INotifyPropertyChanged
    {
        //Etat courant de l'automate
        private Etat etatCourant;
        //Etat initial de l'automate
        private Etat etatInitial;

        //Dernière étape de transition réalisée
        public Etape EtapeTransition
        {
            get => etapeTransition;
            set
            {
                etapeTransition = value;
                this.NotifyPropertyChanged("EtapeTransition");
            }
        }
        private Etape etapeTransition;

        /// <summary>
        /// L'automate est-il actuellement dans un état terminal
        /// </summary>
        public bool EstDansUnEtatTerminal => etatCourant.EstTerminal;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="etatInitial">Etat initial</param>
        public Automate(Etat etatInitial)
        {
            this.etatInitial = etatInitial;
            this.EtapeTransition = new Etape('\0',etatInitial.Nom);
        }

        /// <summary>
        /// Fait évoluer l'automate
        /// </summary>
        /// <param name="evenement">Caractère lu du mot</param>
        private void Evoluer(Char evenement)
        {
            if (this.etatCourant != null)
            {
                this.etatCourant = this.etatCourant.Transition(evenement);
                this.EtapeTransition = new Etape(evenement, etatCourant.Nom);
            }
        }

        /// <summary>
        /// Le mot est-il valide
        /// </summary>
        /// <param name="mot">Le mot à tester</param>
        /// <returns>Est-il valide</returns>
        public bool EstValide(MotLisibleLettreALettre mot)
        {
            this.etatCourant = this.etatInitial;
            Char c;
            while ((c = mot.NextChar()) != '\0') this.Evoluer(c);
            return this.EstDansUnEtatTerminal;
        }

        //Pattern d'observation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
