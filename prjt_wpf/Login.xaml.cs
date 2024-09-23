using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {


            string userName = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SqlConnection con = new SqlConnection();
            String strCon = "Data Source=MEDELMAKHFI\\SQLEXPRESS;Initial Catalog=GestionEtudiants;Integrated Security=True";
            con.ConnectionString = strCon;

            DataClasses1DataContext cl = new DataClasses1DataContext();
            var x = (from user in cl.admins
                     where user.username == userName && user.password == password
                     select user.password).SingleOrDefault();

            if (x == null)
            {
                MessageBox.Show("Login ou mot de passe incorrect !!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            }
        }
    }
}
