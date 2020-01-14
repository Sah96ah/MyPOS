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
    /// Interaction logic for NewBillControl.xaml
    /// </summary>
    public partial class NewBillControl : UserControl
    {
        public NewBillControl()
        {
            InitializeComponent();
            fillCombo1();
            txtCurrentDate.Text = DateTime.Now.ToShortDateString();
            clearAll();
        }

        //globals
        string unitPrice;
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        void fillCombo1()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT DISTINCT catogory FROM Stock";
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                SqlDataReader rd =  cmd.ExecuteReader();
                while (rd.Read())
                {
                    cmbProduct.Items.Add(rd["catogory"].ToString());
                }
            }
        }

        private void clearAll()
        {
            cmbProductID.Items.Clear();
            txtProductDes.Text = "";
            txtQuality.Text = "";
            txtSubTotal.Text = "";
            txtUnitPrice.Text = "";
            cmbProductID.SelectedIndex = -1;
        }

        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clearAll();

            if (cmbProduct.SelectedItem.ToString() == "")
            {
                productValidator.Visibility = Visibility.Visible;
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT DISTINCT productID FROM Stock WHERE catogory='" + cmbProduct.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cmbProductID.Items.Add(rd["productID"].ToString());
                }
            }

        }

        private void cmbProductID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbProductID.SelectedIndex != -1)
            {
                int pId = int.Parse(cmbProductID.SelectedItem.ToString());
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT description FROM Stock WHERE productID=" + pId.ToString();
                    string query2 = "SELECT unitPrice FROM Stock WHERE productID=" + pId.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    con.Open();
                    txtProductDes.Text = (cmd.ExecuteScalar()).ToString();
                    txtUnitPrice.Text = (cmd2.ExecuteScalar()).ToString();
                    //because this is readonly
                    unitPrice = (cmd2.ExecuteScalar()).ToString();
                }
            
            }
        }

        private void txtQuality_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtQuality.Text != "")
            {
                decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
                decimal quantity = decimal.Parse(txtQuality.Text);

                decimal subtotal = unitPrice * quantity;

                txtSubTotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubTotal.Text = "";
            }
        }

        private void txtDiscount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                decimal dicper = decimal.Parse(txtDiscount.Text);
                decimal total = decimal.Parse(txtSubTotal.Text)-(dicper * decimal.Parse(txtSubTotal.Text)) / 100;
                txtTotal.Text = total.ToString(); 
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string s1 = cmbProductID.SelectedItem.ToString();
            string s2 = cmbProduct.SelectedItem.ToString();
            string s3 = txtProductDes.Text;
            decimal d1 = decimal.Parse(txtQuality.Text);
            decimal d2 = decimal.Parse(unitPrice);
            decimal d3 = decimal.Parse(txtDiscount.Text);
            decimal d4 = decimal.Parse(txtSubTotal.Text);
            decimal d5 = decimal.Parse(txtTotal.Text);

            int billno = 100;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Sales (productID,catogory,quantity,unitprice,discount,subtotal,total,billno,description,billdate) VALUES ('" + s1+"','"+s2+"',"+d1+","+d2+","+d3+","+d4+","+d5+","+billno+",'"+s3+"','"+txtCurrentDate.Text+"')";
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
