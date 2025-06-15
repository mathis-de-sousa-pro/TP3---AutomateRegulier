using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les mots finissant par ".fr" ou ".com"
    /// </summary>
    public class AlgorithmeFinissantParFRouCOM : Algorithme
    {
        public AlgorithmeFinissantParFRouCOM()
        {
            Etat q0 = new Etat("Initial");
            Etat p1 = new Etat(".");
            Etat f2 = new Etat(".f");
            Etat fr = new Etat(".fr");
            Etat c2 = new Etat(".c");
            Etat co = new Etat(".co");
            Etat com = new Etat(".com");

            fr.EstTerminal = true;
            com.EstTerminal = true;

            q0.EtatParDefaut = q0;
            p1.EtatParDefaut = q0;
            f2.EtatParDefaut = q0;
            fr.EtatParDefaut = q0;
            c2.EtatParDefaut = q0;
            co.EtatParDefaut = q0;
            com.EtatParDefaut = q0;

            q0.AddTransition('.', p1);

            p1.AddTransition('f', f2);
            p1.AddTransition('c', c2);
            p1.AddTransition('.', p1);

            f2.AddTransition('r', fr);
            f2.AddTransition('.', p1);

            fr.AddTransition('.', p1);

            c2.AddTransition('o', co);
            c2.AddTransition('.', p1);

            co.AddTransition('m', com);
            co.AddTransition('.', p1);

            com.AddTransition('.', p1);

            this.Automate = new Automate(q0);
        }
    }
}
