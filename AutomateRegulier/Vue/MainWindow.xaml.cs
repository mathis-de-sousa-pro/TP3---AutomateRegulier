using AutomateRegulier.VueModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomateRegulier.Vue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //VueModèle
        private VMVuePrincipale vueModele;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public MainWindow()
        {
            this.vueModele = new VMVuePrincipale();
            this.DataContext = this.vueModele;
            InitializeComponent();
        }

        /// <summary>
        /// Changement de la liste des mots
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListMots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.vueModele.MotSelectionne = null;
            if(e.AddedItems.Count>0)
            {
                var newItem = e.AddedItems[0];
                foreach(var item in this.ListMots.Items)
                {
                    if (item != newItem) this.ListMots.SelectedItems.Remove(item);
                }
                this.vueModele.MotSelectionne = (VMMot) newItem;
            }
        }
    }
}
