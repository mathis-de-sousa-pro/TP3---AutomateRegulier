using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme
{
    /// <summary>
    /// Décoration du mot avec une lecture caractère par caractère
    /// </summary>
    public class MotLisibleLettreALettre
    {
        //Le mot
        private Mot mot;
        //Là où en est la lecture
        private int position;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="mot">Le mot</param>
        public MotLisibleLettreALettre(Mot mot)
        {
            if (mot == null) this.mot = new Mot("");
            else this.mot = mot;
            this.position = 0;
        }

        /// <summary>
        /// Renvoie le caractère suivant
        /// </summary>
        /// <returns>Le caractère suivant où '\0' à la fin du mot</returns>
        public Char NextChar()
        {
            Char res = '\0';
            if (this.position < this.mot.Length)
            {
                res = this.mot.ToString()[this.position];
                position++;
            }
            return res;
        }
    }
}
