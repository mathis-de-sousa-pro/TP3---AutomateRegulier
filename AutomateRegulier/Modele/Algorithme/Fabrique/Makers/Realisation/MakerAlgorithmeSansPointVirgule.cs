using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme SansPointVirgule
    /// </summary>
    public class MakerAlgorithmeSansPointVirgule : IMakerAlgorithme
    {
        public string NomAlgorithme => "SansPointVirgule";

        public Algorithme Creer()
        {
            return new AlgorithmeSansPointVirgule();
        }
    }
}
