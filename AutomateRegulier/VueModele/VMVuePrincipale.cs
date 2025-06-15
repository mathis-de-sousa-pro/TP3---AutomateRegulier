using AutomateRegulier.Modele;
using AutomateRegulier.Modele.Algorithme;
using AutomateRegulier.Modele.Algorithme.Automates;
using AutomateRegulier.Modele.Algorithme.Fabrique;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateRegulier.VueModele
{
    /// <summary>
    /// VueModèle principale
    /// </summary>
    public class VMVuePrincipale : INotifyPropertyChanged
    {

        //Fabrique abstraite des algorithmes
        private FarbiqueAlgorithme fabrique;

        /// <summary>
        /// Liste des mots à tester
        /// </summary>
        public ObservableCollection<VMMot> Mots => mots;
        private ObservableCollection<VMMot> mots;

        /// <summary>
        /// Mot sélectionné dans la liste
        /// </summary>
        public VMMot MotSelectionne
        {
            get => motSelectionne;
            set
            {
                motSelectionne = value;
                if (value != null) this.AnaliserUnMot(motSelectionne);
            }
        }
        private VMMot motSelectionne;

        /// <summary>
        /// Liste des étapes pour le mot selectionné
        /// </summary>
        public ObservableCollection<Etape> Etapes => etapes;
        private ObservableCollection<Etape> etapes;

        /// <summary>
        /// Algorithme selectionné
        /// </summary>
        public string NomAlgorithmeSelectionne
        {
            get => nomAlgorithmeSelectionne; 
            set
            {
                nomAlgorithmeSelectionne = value;
                if (value != null) this.LancerAlgorithme();
            }
        }
        private string nomAlgorithmeSelectionne;


        /// <summary>
        /// Liste des algorithmes
        /// </summary>
        public String[] ListeAlgorithmes => fabrique.Liste;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public VMVuePrincipale()
        {
            this.nomAlgorithmeSelectionne = "";
            this.fabrique = new FarbiqueAlgorithme();
            this.mots = new ObservableCollection<VMMot>();
            this.etapes = new ObservableCollection<Etape>();

            //Ajouter ici les mots test
            this.mots.Add(new VMMot("Aberration"));
            this.mots.Add(new VMMot("Alentour"));
            this.mots.Add(new VMMot("Bonjour"));
        }

        /// <summary>
        /// Lance l'algorithme sélectionné
        /// </summary>
        public void LancerAlgorithme()
        {
            Algorithme? algorithme = fabrique.Creer(this.nomAlgorithmeSelectionne);
            if(algorithme != null)
            {
                foreach (VMMot mot in this.mots)
                {
                    mot.EstValide = algorithme.EstValide(mot.Metier);
                }
                this.NotifyPropertyChanged("Mots");
                this.AnaliserUnMot(this.MotSelectionne);
            }
        }

        /// <summary>
        /// Analyse un mot
        /// </summary>
        /// <param name="mot">Le mot à analyser</param>
        public void AnaliserUnMot(VMMot mot) 
        {
            this.etapes.Clear();
            if(this.NomAlgorithmeSelectionne != null && mot != null)
            {
                Algorithme? algorithme = fabrique.Creer(this.nomAlgorithmeSelectionne);
                if(algorithme!=null)
                {
                    algorithme.EstValide(mot.Metier);
                    foreach (Etape etape in algorithme.Etapes) Etapes.Add(etape);
                }
            }
        }

        //Pattern d'observation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
