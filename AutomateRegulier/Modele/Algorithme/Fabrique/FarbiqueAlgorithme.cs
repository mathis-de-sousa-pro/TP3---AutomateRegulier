using AutomateRegulier.Modele.Algorithme.Fabrique.Makers;
using AutomateRegulier.Modele.Algorithme.Fabrique.Makers.Realisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.Modele.Algorithme.Fabrique
{
    /// <summary>
    /// Fabrique abstraite
    /// </summary>
    public class FarbiqueAlgorithme
    {
        //Liste des maker enregistrés dans la fabrique
        private Dictionary<string, IMakerAlgorithme> makers;

        //Liste des noms des makers
        public String[] Liste => this.makers.Keys.ToArray();

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public FarbiqueAlgorithme()
        {
            this.makers = new Dictionary<string, IMakerAlgorithme>();
            this.Initialisation();
        }

        /// <summary>
        /// Initialise la fabrique en enregistrant les différents algorithmes
        /// </summary>
        private void Initialisation()
        {

            // Enregistrement des différents algorithmes
            this.Enregistrer(new MakerAlgorithmeExemple());
            this.Enregistrer(new MakerAlgorithmeCommenceParHttp());
            this.Enregistrer(new MakerAlgorithmeCommenceParHTTPouWWW());
            this.Enregistrer(new MakerAlgorithmeFinissantParFR());
            this.Enregistrer(new MakerAlgorithmeFinissantParFRouCOM());
            this.Enregistrer(new MakerAlgorithmeSansPointVirgule());
            this.Enregistrer(new MakerAlgorithmeMDP());
            this.Enregistrer(new MakerAlgorithmeDATE());

        }

        /// <summary>
        /// Enregistrement d'un algorithme
        /// </summary>
        /// <param name="algorithme">L'algorithme à enregistrer</param>
        private void Enregistrer(IMakerAlgorithme maker)
        {
            if(maker != null) this.makers[maker.NomAlgorithme] = maker;
        }

        /// <summary>
        /// Crée l'algorithme demandé
        /// </summary>
        /// <param name="nom">Nom de l'algorithme</param>
        /// <returns>L'algorithme (ou null s'il n'existe pas)</returns>
        public Algorithme? Creer(string nom)
        {
            Algorithme? res = null;
            if (this.makers.ContainsKey(nom) && this.makers[nom] != null) res = this.makers[nom].Creer();
            return res;
        }


    }
}
