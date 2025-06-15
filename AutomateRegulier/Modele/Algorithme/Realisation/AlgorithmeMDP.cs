using AutomateRegulier.Modele.Algorithme.Automates;

namespace AutomateRegulier.Modele.Algorithme.Realisation
{
    /// <summary>
    /// Automate reconnaissant les mots contenant au moins une minuscule,
    /// une majuscule et un chiffre.
    /// </summary>
    public class AlgorithmeMDP : Algorithme
    {
        public AlgorithmeMDP()
        {
            // Etats representant les combinaisons des categories rencontrees
            Etat none = new Etat("None");
            Etat lower = new Etat("Lower");
            Etat upper = new Etat("Upper");
            Etat digit = new Etat("Digit");
            Etat lowerUpper = new Etat("LowerUpper");
            Etat lowerDigit = new Etat("LowerDigit");
            Etat upperDigit = new Etat("UpperDigit");
            Etat all = new Etat("All");

            // Etat final
            all.EstTerminal = true;
            all.EtatParDefaut = all;

            // Tous les autres etats bouclent sur eux-memes par defaut
            none.EtatParDefaut = none;
            lower.EtatParDefaut = lower;
            upper.EtatParDefaut = upper;
            digit.EtatParDefaut = digit;
            lowerUpper.EtatParDefaut = lowerUpper;
            lowerDigit.EtatParDefaut = lowerDigit;
            upperDigit.EtatParDefaut = upperDigit;

            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";

            foreach (char c in lowers)
            {
                none.AddTransition(c, lower);
                upper.AddTransition(c, lowerUpper);
                digit.AddTransition(c, lowerDigit);
                upperDigit.AddTransition(c, all);
                lower.AddTransition(c, lower);
                lowerUpper.AddTransition(c, lowerUpper);
                lowerDigit.AddTransition(c, lowerDigit);
                all.AddTransition(c, all);
            }
            foreach (char c in uppers)
            {
                none.AddTransition(c, upper);
                lower.AddTransition(c, lowerUpper);
                digit.AddTransition(c, upperDigit);
                lowerDigit.AddTransition(c, all);
                upper.AddTransition(c, upper);
                lowerUpper.AddTransition(c, lowerUpper);
                upperDigit.AddTransition(c, upperDigit);
                all.AddTransition(c, all);
            }
            foreach (char c in digits)
            {
                none.AddTransition(c, digit);
                lower.AddTransition(c, lowerDigit);
                upper.AddTransition(c, upperDigit);
                lowerUpper.AddTransition(c, all);
                digit.AddTransition(c, digit);
                lowerDigit.AddTransition(c, lowerDigit);
                upperDigit.AddTransition(c, upperDigit);
                all.AddTransition(c, all);
            }

            this.Automate = new Automate(none);
        }
    }
}
