using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers
{
    /// <summary>
    /// Maker d'algorithme pour la fabrique abstraite
    /// </summary>
    public interface IMakerAlgorithme
    {
        string NomAlgorithme { get; }

        /// <summary>
        /// Création de l'algorithme
        /// </summary>
        /// <returns>L'algorithme créé</returns>
        Algorithme Creer();
    }
}
