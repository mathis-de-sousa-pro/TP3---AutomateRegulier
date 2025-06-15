using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Automates
{
    /// <summary>
    /// Etat erreur (boucle sur lui même indéfiniment et est non valide)
    /// </summary>
    public class EtatErreur : Etat
    {

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public EtatErreur() : base("Erreur",null)
        {
            this.EtatParDefaut = this;
        }
    }
}
