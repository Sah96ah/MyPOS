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
            fillCombo();
        }

        private void fillCombo()
        {
            cmbUsertype.Items.Add("Admin");
            cmbUsertype.Items.Add("User");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsertype.SelectedItem.ToString()=="User")
            {
                UserDashBoard w2 = new UserDashBoard();
                w2.Show();
                this.Close();
            }
            else if(cmbUsertype.SelectedItem.ToString() == "Admin") 
            {
                AdminDashBoard w2 = new AdminDashBoard();
                w2.Show();
                this.Close();
            }
            
        }

       
    }
}
