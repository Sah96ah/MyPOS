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
    /// Interaction logic for UserDashBoard.xaml
    /// </summary>
    public partial class UserDashBoard : Window
    {
        public UserDashBoard()
        {
            InitializeComponent();
            NewBillControl w0 = new NewBillControl();
            gridswitcher1.Children.Add(w0);

            SalesReturnControl w1 = new SalesReturnControl();
            gridswitcher2.Children.Add(w1);

            SalesReportControl w2 = new SalesReportControl();
            gridswitcher3.Children.Add(w2);

            gridswitcher1.Visibility = Visibility.Visible;
            gridswitcher2.Visibility = Visibility.Hidden;
            gridswitcher3.Visibility = Visibility.Hidden;

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
                    gridswitcher3.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    
                    gridswitcher1.Visibility = Visibility.Hidden;
                    gridswitcher2.Visibility = Visibility.Visible;
                    gridswitcher3.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    gridswitcher1.Visibility = Visibility.Hidden;
                    gridswitcher2.Visibility = Visibility.Hidden;
                    gridswitcher3.Visibility = Visibility.Visible;
                    break;

            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w4 = new MainWindow();
            w4.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
