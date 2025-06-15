using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Automates
{
    /// <summary>
    /// Etat générique de l'automate
    /// </summary>
    public class Etat
    {
        //Liste des transitions
        private Dictionary<char, Etat> transitions;


        /// <summary>
        /// Nom de l'état
        /// </summary>
        public String Nom { get => nom; set => nom = value; }
        private string nom;

        /// <summary>
        /// Etat par défaut (si aucune transition n'est prévu). Initialisé à EtatErreur
        /// </summary>
        public Etat EtatParDefaut { set => this.etatParDefaut = value; }
        private Etat etatParDefaut;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="nom">Nom de l'état</param>
        public Etat(string nom) : this(nom, new EtatErreur())
        {
        }

        /// <summary>
        /// Constructeur interne pour éviter la récursivité de l'état d'erreur
        /// </summary>
        /// <param name="nom">Nom de l'état</param>
        /// <param name="ettatParDefaut">Etat de transition par défaut</param>
        protected Etat(string nom, Etat ettatParDefaut)
        {
            this.nom = nom;
            this.estTerminal = false;
            this.transitions = new Dictionary<char, Etat>();
            this.etatParDefaut = ettatParDefaut;
        }

        /// <summary>
        /// Transition de l'état
        /// </summary>
        /// <param name="evenement">Caractère lu</param>
        /// <returns>Le nouvel état</returns>
        public Etat Transition(char evenement)
        {
            Etat nouvelEtat = this.etatParDefaut;
            if (this.transitions.ContainsKey(evenement)) nouvelEtat = this.transitions[evenement];
            return nouvelEtat;
        }

        /// <summary>
        /// L'état est-il un état terminal (valide)
        /// </summary>
        public bool EstTerminal { get => estTerminal; set => estTerminal = value; }
        private bool estTerminal;

        /// <summary>
        /// Ajoute une transition
        /// </summary>
        /// <param name="evenement">Evenement trigger</param>
        /// <param name="nouvelEtat">Nouvel etat</param>
        public void AddTransition(char evenement, Etat nouvelEtat)
        {
            this.transitions[evenement] = nouvelEtat;
        }

    }
}
