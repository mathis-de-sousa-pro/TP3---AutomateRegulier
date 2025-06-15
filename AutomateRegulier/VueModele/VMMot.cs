using AutomateRegulier.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AutomateRegulier.VueModele
{
    /// <summary>
    /// Vue Modele d'un mot
    /// </summary>
    public class VMMot : INotifyPropertyChanged
    {
        /// <summary>
        /// Metier
        /// </summary>
        public Mot Metier => metier;
        private Mot metier;

        /// <summary>
        /// Nom du mot
        /// </summary>
        public string Nom => this.metier.ToString();

        //Le mot est-il valide (0=non testé, -1 non, +1 oui)
        public int CasValide => casValide;
        private int casValide;

        //Valide ou invalide le mot
        public bool EstValide { 
            set
            {
                if (value) casValide = 1;
                else casValide = -1;
                this.NotifyPropertyChanged("CasValide");
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="mot">Le mot</param>
        public VMMot(String mot)
        {
            this.metier = new Mot(mot);
            this.casValide = 0; 
        }


        //Pattern d'observation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
