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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl1 filiereCntr = new UserControl1();
        StatisticUserControl statisticCntrl = new StatisticUserControl();
        GestionEtudiant etudCntrl = new GestionEtudiant();
        public MainWindow()
        {
            InitializeComponent();
            cntrlFrame.Content = etudCntrl;

        }

        

        
       

        private void BtnFiliere_Click(object sender, RoutedEventArgs e)
        {
            cntrlFrame.Content = filiereCntr;

        }

        private void BtnEtud_Click_1(object sender, RoutedEventArgs e)
        {
            cntrlFrame.Content = etudCntrl;
        }

        private void BtnStatistic_Click_1(object sender, RoutedEventArgs e)
        {
            cntrlFrame.Content = statisticCntrl;

        }
    }
}
