using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les mots commençant par "Http://"
    /// </summary>
    public class AlgorithmeCommenceParHttp : Algorithme
    {
        public AlgorithmeCommenceParHttp()
        {
            // Création des états
            Etat e0 = new Etat("Etat Initial");
            Etat e1 = new Etat("H lu");
            Etat e2 = new Etat("Ht lu");
            Etat e3 = new Etat("Htt lu");
            Etat e4 = new Etat("Http lu");
            Etat e5 = new Etat("Http: lu");
            Etat e6 = new Etat("Http:/ lu");
            Etat e7 = new Etat("Http:// lu");

            // Etat final
            e7.EstTerminal = true;

            // Boucle terminale
            e7.EtatParDefaut = e7;

            // Définition des transitions
            e0.AddTransition('H', e1);
            e1.AddTransition('t', e2);
            e2.AddTransition('t', e3);
            e3.AddTransition('p', e4);
            e4.AddTransition(':', e5);
            e5.AddTransition('/', e6);
            e6.AddTransition('/', e7);

            // Etats d'erreur par défaut
            // (les états non terminaux renvoient vers l'erreur pour tout autre caractère)
            // L'état initial renvoie vers l'erreur si la première lettre n'est pas H
            this.Automate = new Automate(e0);
        }
    }
}
