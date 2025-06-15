using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele
{
    /// <summary>
    /// Classe métier représentant un mot à tester
    /// </summary>
    public class Mot
    {
        //Contenu (le mot en lui même)
        private string contenu;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="contenu">Le mot</param>
        public Mot(string contenu)
        {
            if (contenu == null) this.contenu = "";
            else this.contenu = contenu;
        }

        /// <summary>
        /// Longueur du mot
        /// </summary>
        public int Length => this.contenu.Length;


        public override string ToString()
        {
            return contenu;
        }
    }
}
