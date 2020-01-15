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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MyPos
{
    /// <summary>
    /// Interaction logic for SalesReturnControl.xaml
    /// </summary>
    public partial class SalesReturnControl : UserControl
    {
        public SalesReturnControl()
        {
            InitializeComponent();
        }

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            long bno = long.Parse(txtbillNo.Text);
            int pID = int.Parse(txtProductID.Text);

            using (SqlConnection con = new SqlConnection(cs)) 
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT date,quantity,unitprice,total FROM Sales WHERE billno=" + bno + " AND productID="+pID;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txtDate.Text = rd.GetValue(0).ToString();
                    txtQuantity.Text = rd.GetValue(1).ToString();
                    txtUnitPrice.Text = rd.GetValue(2).ToString();
                    txtTotal.Text = rd.GetValue(3).ToString();
                }
            }

        }
        //not allow other than numeric value in text box
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}


