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

namespace MyPos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void btnAdminSwitcher_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin w1 = new AdminLogin();
            w1.Show();
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserDashBoard w2 = new UserDashBoard();
            w2.Show();
            this.Close();
        }
    }
}
