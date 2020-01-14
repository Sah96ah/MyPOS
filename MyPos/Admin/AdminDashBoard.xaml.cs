using MyPos.Admin;
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
    

            AdminAddProductControl w1 = new AdminAddProductControl();
            AdminAddCatogory w2 = new AdminAddCatogory(); 
            AdminAddUsersControl w5 = new AdminAddUsersControl();

            gridswitcher1.Children.Add(w1);
            gridswitcher2.Children.Add(w2);
            gridswitcher5.Children.Add(w5);
            
            gridswitcher1.Visibility = Visibility.Visible;
            gridswitcher2.Visibility = Visibility.Hidden;
            gridswitcher5.Visibility = Visibility.Hidden;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {

            MainWindow w1 = new MainWindow();
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
                    gridswitcher1.Visibility = Visibility.Visible;
                    gridswitcher2.Visibility = Visibility.Hidden;
                    gridswitcher5.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    gridswitcher2.Visibility = Visibility.Visible;
                    gridswitcher1.Visibility = Visibility.Hidden; 
                    gridswitcher5.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    break;
                case 3:
                    
                    break;
                case 4:
                    gridswitcher5.Visibility = Visibility.Visible;
                    gridswitcher1.Visibility = Visibility.Hidden;
                    break;

            }
        }
    }
}
