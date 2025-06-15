using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme CommenceParHTTPouWWW
    /// </summary>
    public class MakerAlgorithmeCommenceParHTTPouWWW : IMakerAlgorithme
    {
        public string NomAlgorithme => "CommenceParHTTPouWWW";

        public Algorithme Creer()
        {
            return new AlgorithmeCommenceParHTTPouWWW();
        }
    }
}
