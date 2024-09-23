using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public static DataClasses1DataContext cl = new DataClasses1DataContext();
        public static ObservableCollection<filiere> liste1 = new ObservableCollection<filiere>(cl.GetTable<filiere>()) ;
   
        FiliereOperation f = new FiliereOperation(cl,liste1);
       
        public UserControl1()
        {
            
            InitializeComponent();
        }

       private void RadCarousel_Loaded(object sender, RoutedEventArgs e)
        {
            Rad.ItemsSource = f.afficher();

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (IsValidInput())
            {
                f.modifier(int.Parse(textbox1.Text), textbox2.Text, textbox3.Text);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (IsValidInputForDelete())
            {
                f.supprimer(int.Parse(textbox1.Text));
            }
            else
            {
                MessageBox.Show("Veuillez fournir un ID valide avant de supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInputForAdd())
            {
                f.ajouter(textbox2.Text, textbox3.Text);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs avant d'ajouter.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidInput()
        {
            return !string.IsNullOrWhiteSpace(textbox1.Text) && !string.IsNullOrWhiteSpace(textbox2.Text) && !string.IsNullOrWhiteSpace(textbox3.Text);
        }

        private bool IsValidInputForDelete()
        {
            return !string.IsNullOrWhiteSpace(textbox1.Text);
        }

        private bool IsValidInputForAdd()
        {
            return !string.IsNullOrWhiteSpace(textbox2.Text) && !string.IsNullOrWhiteSpace(textbox3.Text);
        }

    }
}
