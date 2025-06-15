using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme CommenceParHttp
    /// </summary>
    public class MakerAlgorithmeCommenceParHttp : IMakerAlgorithme
    {
        public string NomAlgorithme => "CommenceParHttp";

        public Algorithme Creer()
        {
            return new AlgorithmeCommenceParHttp();
        }
    }
}
