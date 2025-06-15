using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme MDP (mot de passe)
    /// </summary>
    public class MakerAlgorithmeMDP : IMakerAlgorithme
    {
        public string NomAlgorithme => "MDP";

        public Algorithme Creer()
        {
            return new AlgorithmeMDP();
        }
    }
}
