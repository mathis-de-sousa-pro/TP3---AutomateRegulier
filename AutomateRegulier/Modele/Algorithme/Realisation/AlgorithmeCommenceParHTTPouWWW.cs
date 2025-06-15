using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les mots commençant par "Http://" ou par "www"
    /// </summary>
    public class AlgorithmeCommenceParHTTPouWWW : Algorithme
    {
        public AlgorithmeCommenceParHTTPouWWW()
        {
            // Etats communs
            Etat i = new Etat("Etat Initial");

            // Chemin Http://
            Etat h1 = new Etat("H lu");
            Etat h2 = new Etat("Ht lu");
            Etat h3 = new Etat("Htt lu");
            Etat h4 = new Etat("Http lu");
            Etat h5 = new Etat("Http: lu");
            Etat h6 = new Etat("Http:/ lu");
            Etat h7 = new Etat("Http:// lu");

            // Chemin www
            Etat w1 = new Etat("w lu");
            Etat w2 = new Etat("ww lu");
            Etat w3 = new Etat("www lu");

            // Etat final
            Etat f = new Etat("Prefixe reconnu");
            f.EstTerminal = true;
            f.EtatParDefaut = f;

            // Transitions Http://
            i.AddTransition('H', h1);
            h1.AddTransition('t', h2);
            h2.AddTransition('t', h3);
            h3.AddTransition('p', h4);
            h4.AddTransition(':', h5);
            h5.AddTransition('/', h6);
            h6.AddTransition('/', h7);
            h7.EtatParDefaut = f;

            // Transitions www
            i.AddTransition('w', w1);
            w1.AddTransition('w', w2);
            w2.AddTransition('w', w3);
            w3.EtatParDefaut = f;

            // Initialise l'automate
            this.Automate = new Automate(i);
        }
    }
}
