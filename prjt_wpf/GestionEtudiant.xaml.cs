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

namespace prjt_wpf
{
    /// <summary>
    /// Interaction logic for GestionEtudiant.xaml
    /// </summary>
    public partial class GestionEtudiant : UserControl
    {
        DataClasses1DataContext cl = new DataClasses1DataContext();


        public GestionEtudiant()
        {
            InitializeComponent();
            EtudiantOperation f = new EtudiantOperation();
            Combobox.ItemsSource = f.getNomfiliere();
            
            RadGridV.ItemsSource = f.getaletudiant();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String combobx = Convert.ToString(Combobox.SelectedItem);

            EtudiantOperation f = new EtudiantOperation();
            label1.Content = combobx;
            Mafiliere.Content = combobx;
            RadGridV.ItemsSource = f.getchaquefiliere(combobx);
            ChefFiliere.Content = f.getcheffiliere(combobx);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedEtudiant = RadGridV.SelectedItem as etudiant;

            if (selectedEtudiant != null)
            {
                ModifierEtudiant dr = new ModifierEtudiant(selectedEtudiant);
                dr.Show();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un étudiant avant de cliquer sur Modifier.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

