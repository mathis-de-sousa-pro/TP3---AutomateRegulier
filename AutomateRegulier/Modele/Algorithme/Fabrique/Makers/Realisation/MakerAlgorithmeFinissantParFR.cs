using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme FinissantParFR
    /// </summary>
    public class MakerAlgorithmeFinissantParFR : IMakerAlgorithme
    {
        public string NomAlgorithme => "FinissantParFR";

        public Algorithme Creer()
        {
            return new AlgorithmeFinissantParFR();
        }
    }
}
