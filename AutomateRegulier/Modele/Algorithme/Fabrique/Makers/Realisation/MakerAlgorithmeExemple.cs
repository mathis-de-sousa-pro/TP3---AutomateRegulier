using AutomateRegulier.Modele.Algorithme.Realisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker d'un AlgorithmeExemple
    /// </summary>
    public class MakerAlgorithmeExemple : IMakerAlgorithme
    {
        public string NomAlgorithme => "Exemple";

        public Algorithme Creer()
        {
            return new AlgorithmeExemple();
        }
    }
}
