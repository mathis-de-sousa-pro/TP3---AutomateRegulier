using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Automates
{
    /// <summary>
    /// Etape de l'automate (pour affichage de l'historique)
    /// </summary>
    public class Etape
    {
        /// <summary>
        /// Evenement
        /// </summary>
        public char Evenement => evenement;
        private char evenement;

        /// <summary>
        /// Nom de l'état
        /// </summary>
        public string NomEtat => nomEtat;
        private string nomEtat;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="evenement">Evement parent</param>
        /// <param name="nomEtat">Nom de l'état résultant</param>
        public Etape(char evenement, string nomEtat)
        {
            this.evenement = evenement;
            this.nomEtat = nomEtat;
        }
    }
}
