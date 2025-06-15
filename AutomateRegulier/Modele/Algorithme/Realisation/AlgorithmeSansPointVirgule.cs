using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les mots ne contenant pas de ';'
    /// </summary>
    public class AlgorithmeSansPointVirgule : Algorithme
    {
        public AlgorithmeSansPointVirgule()
        {
            // Etats
            Etat q0 = new Etat("Sans ;");
            Etat erreur = new Etat("Avec ;");

            // Etat terminal : on accepte tant qu'aucun ';' n'a ete lu
            q0.EstTerminal = true;

            // Etats par defaut
            q0.EtatParDefaut = q0;
            erreur.EtatParDefaut = erreur;

            // Transition sur ';' vers l'etat d'erreur
            q0.AddTransition(';', erreur);

            this.Automate = new Automate(q0);
        }
    }
}
