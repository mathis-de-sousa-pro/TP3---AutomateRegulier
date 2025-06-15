using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les dates au format AA/BB/CC
    /// AA entre 01 et 31, BB entre 01 et 12, CC entre 00 et 99.
    /// Les transitions invalident toute chaine ne respectant pas ce motif.
    /// </summary>
    public class AlgorithmeDATE : Algorithme
    {
        public AlgorithmeDATE()
        {
            // Etats pour la lecture du jour
            Etat q0 = new Etat("Start");
            Etat d0 = new Etat("D1=0");
            Etat d1 = new Etat("D1=1");
            Etat d2 = new Etat("D1=2");
            Etat d3 = new Etat("D1=3");

            Etat day28 = new Etat("Day<=28");
            Etat day29 = new Etat("Day29-30");
            Etat day31 = new Etat("Day31");

            // Lecture du mois selon la categorie du jour
            Etat day28_m = new Etat("Mois apres <=28");
            Etat day29_m = new Etat("Mois apres 29-30");
            Etat day31_m = new Etat("Mois apres 31");

            Etat d28_m0 = new Etat("d28 M1=0");
            Etat d28_m1 = new Etat("d28 M1=1");
            Etat d29_m0 = new Etat("d29 M1=0");
            Etat d29_m1 = new Etat("d29 M1=1");
            Etat d31_m0 = new Etat("d31 M1=0");
            Etat d31_m1 = new Etat("d31 M1=1");

            Etat afterValidMonth = new Etat("Mois valide");

            // Lecture de l'annee
            Etat y1 = new Etat("A1");
            Etat y2 = new Etat("A2");
            Etat fin = new Etat("Fin");
            fin.EstTerminal = true;

            // Transitions premier chiffre du jour
            q0.AddTransition('0', d0);
            q0.AddTransition('1', d1);
            q0.AddTransition('2', d2);
            q0.AddTransition('3', d3);

            foreach(char c in "123456789") d0.AddTransition(c, day28); // 01..09
            foreach(char c in "0123456789") d1.AddTransition(c, day28); //10..19
            foreach(char c in "012345678") d2.AddTransition(c, day28); //20..28
            d2.AddTransition('9', day29);                                 //29
            d3.AddTransition('0', day29);                                  //30
            d3.AddTransition('1', day31);                                  //31

            // Slash apres le jour
            day28.AddTransition('/', day28_m);
            day29.AddTransition('/', day29_m);
            day31.AddTransition('/', day31_m);

            // Premier chiffre du mois
            day28_m.AddTransition('0', d28_m0);
            day28_m.AddTransition('1', d28_m1);
            day29_m.AddTransition('0', d29_m0);
            day29_m.AddTransition('1', d29_m1);
            day31_m.AddTransition('0', d31_m0);
            day31_m.AddTransition('1', d31_m1);

            // Mois apres un jour <=28 : tous les mois autorises
            foreach(char c in "123456789") d28_m0.AddTransition(c, afterValidMonth);
            foreach(char c in "012") d28_m1.AddTransition(c, afterValidMonth);

            // Mois apres un jour 29 ou 30 : tous sauf fevrier
            foreach(char c in "13 456789".Replace(" ","")) d29_m0.AddTransition(c, afterValidMonth);
            foreach(char c in "01") d29_m1.AddTransition(c, afterValidMonth); //10,11
            d29_m1.AddTransition('2', afterValidMonth); //12

            // Mois apres un jour 31 : seulement mois a 31 jours
            foreach(char c in "13578") d31_m0.AddTransition(c, afterValidMonth); //01,03,05,07,08
            foreach(char c in "02") d31_m1.AddTransition(c, afterValidMonth);    //10,12

            // Slash apres le mois
            afterValidMonth.AddTransition('/', y1);

            // Annee
            foreach(char c in "0123456789") y1.AddTransition(c, y2);
            foreach(char c in "0123456789") y2.AddTransition(c, fin);

            this.Automate = new Automate(q0);
        }
    }
}
