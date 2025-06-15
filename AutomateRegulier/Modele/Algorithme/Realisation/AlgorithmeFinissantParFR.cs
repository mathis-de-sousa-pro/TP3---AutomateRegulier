using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les mots finissant par ".fr"
    /// </summary>
    public class AlgorithmeFinissantParFR : Algorithme
    {
        public AlgorithmeFinissantParFR()
        {
            // Etats
            Etat q0 = new Etat("Initial");
            Etat q1 = new Etat(".");
            Etat q2 = new Etat(".f");
            Etat q3 = new Etat(".fr");

            // Etat terminal
            q3.EstTerminal = true;

            // Etats par defaut
            q0.EtatParDefaut = q0;
            q1.EtatParDefaut = q0;
            q2.EtatParDefaut = q0;
            q3.EtatParDefaut = q0;

            // Transitions
            q0.AddTransition('.', q1);

            q1.AddTransition('f', q2);
            q1.AddTransition('.', q1);

            q2.AddTransition('r', q3);
            q2.AddTransition('.', q1);

            q3.AddTransition('.', q1);

            this.Automate = new Automate(q0);
        }
    }
}
