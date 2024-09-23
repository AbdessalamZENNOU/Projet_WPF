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
using System.Windows.Shapes;

namespace prjt_wpf
{
    /// <summary>
    /// Interaction logic for ModifierEtudiant.xaml
    /// </summary>
    public partial class ModifierEtudiant : Window
    {
        private etudiant Etudiant;
        private EtudiantOperation EtudiantOp;
        public ModifierEtudiant(etudiant etudiant)
        {
            InitializeComponent();
            EtudiantOp = new EtudiantOperation();
            Etudiant = etudiant;
            Dataform.ItemsSource = new List<etudiant> { Etudiant };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            etudiant et = Dataform.CurrentItem as etudiant;
            EtudiantOperation f = new EtudiantOperation();

            f.ajouter(et);

            MessageBox.Show("Ajout avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void dataForm_DeletingItem(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EtudiantOperation f = new EtudiantOperation();
            f.Delete(Etudiant.cne.ToString());
            MessageBox.Show("Suppression avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EtudiantOperation f = new EtudiantOperation();
            f.modifier(Etudiant);
            MessageBox.Show("Modification avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
