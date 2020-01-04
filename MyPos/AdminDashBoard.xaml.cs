using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPos
{
    /// <summary>
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : Window
    {
        public AdminDashBoard()
        {
            InitializeComponent();
            //manage users control
            AdminAddUsersControl w1 = new AdminAddUsersControl();
            gridswitcher4.Children.Add(w1);
            gridswitcher4.Visibility = Visibility.Hidden;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {

            AdminLogin w1 = new AdminLogin();
            w1.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            tabslider.Margin = new Thickness((150 * index), 0, 0, 0);

            // tab view switches
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    gridswitcher4.Visibility = Visibility.Visible;
                    break;

            }
        }
    }
}
