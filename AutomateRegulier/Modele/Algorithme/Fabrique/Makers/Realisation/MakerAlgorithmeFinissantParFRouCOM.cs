using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme FinissantParFRouCOM
    /// </summary>
    public class MakerAlgorithmeFinissantParFRouCOM : IMakerAlgorithme
    {
        public string NomAlgorithme => "FinissantParFRouCOM";

        public Algorithme Creer()
        {
            return new AlgorithmeFinissantParFRouCOM();
        }
    }
}
