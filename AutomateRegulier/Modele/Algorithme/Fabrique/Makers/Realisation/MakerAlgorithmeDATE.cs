using AutomateRegulier.Modele.Algorithme.Realisation;

namespace AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation
{
    /// <summary>
    /// Maker pour l'algorithme DATE
    /// </summary>
    public class MakerAlgorithmeDATE : IMakerAlgorithme
    {
        public string NomAlgorithme => "DATE";

        public Algorithme Creer()
        {
            return new AlgorithmeDATE();
        }
    }
}
