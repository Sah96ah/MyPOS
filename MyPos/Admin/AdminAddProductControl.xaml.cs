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
using System.Data;

namespace MyPos
{
    /// <summary>
    /// Interaction logic for AdminAddProductControl.xaml
    /// </summary>
    public partial class AdminAddProductControl : UserControl
    {
        public AdminAddProductControl()
        {
            InitializeComponent();
            Hidevisibilites();
            fillDataGrid();
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        
        //globals
        int pId;
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        private void fillDataGrid()
        {
            string cmd1 = string.Empty;
            using (SqlConnection con = new SqlConnection(cs))
            {
                cmd1 = "SELECT productID,catogory,description,unitPrice,quantity FROM Stock";
                SqlCommand cmd = new SqlCommand(cmd1, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Employee");
                sda.Fill(dt);
                grdStockDetails.ItemsSource = dt.DefaultView;

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Hidevisibilites();

            string p1 = txtCatogory.Text;
            string p2 = txtDescription.Text;
            string p3 = txtProductId.Text;
            string p4 = txtUnitPrice.Text;
            string p5 = txtQuantity.Text;

            RequiredValidation(p1,p2,p3,p4,p5);

            if (CanSubmit() == true && CheckProductID()==false) 
            {
                   using(SqlConnection con = new SqlConnection(cs))
                   { 
                    string query = "INSERT INTO Stock (productID,catogory,description,unitPrice,quantity) VALUES (" + int.Parse(p3) + ",'" + p1 + "','" + p2 + "'," + decimal.Parse(p4) + "," + int.Parse(p5) + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                   }
                    fillDataGrid();
            }
        }

        protected void RequiredValidation(string p1, string p2, string p3, string p4, string p5)
        {

            if (p1 == "")
                CatogoryValidator.Visibility = Visibility.Visible;
            if (p2 == "")
                DescriptionValidator.Visibility = Visibility.Visible;
            if (p3 == "")
                ProductIdValidator.Visibility = Visibility.Visible;
            if (p4 == "")
                UnitPriceValidator.Visibility = Visibility.Visible;
            if (p5 == "")
                QuantityValidator.Visibility = Visibility.Visible;
        }
        
        protected void Hidevisibilites()
        {
            CatogoryValidator.Visibility = Visibility.Hidden;
            DescriptionValidator.Visibility = Visibility.Hidden;
            ProductIdValidator.Visibility = Visibility.Hidden;
            UnitPriceValidator.Visibility = Visibility.Hidden;
            QuantityValidator.Visibility = Visibility.Hidden;
        }
        
        private bool CanSubmit()
        {
            if (CatogoryValidator.Visibility == Visibility.Hidden &&
                DescriptionValidator.Visibility == Visibility.Hidden &&
                ProductIdValidator.Visibility == Visibility.Hidden &&
                UnitPriceValidator.Visibility == Visibility.Hidden &&
                QuantityValidator.Visibility == Visibility.Hidden)
                return true;
            else
                return false;
        }

        private bool CheckProductID()
        {
            int temp = int.Parse(txtProductId.Text);
            string chkpID = "SELECT count(*) from Stock where productID="+ temp;
            
            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(chkpID, con2);
            con2.Open();
            int temp2 = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
            con2.Close();
            if (temp2 == 1)
            {
                ProductIdValidator.Visibility = Visibility.Visible;
                ProductIdValidator.Content = "Product ID already exist";
                return true;
            }

            return false;

        }

        protected void grdStockDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             DataGrid gd = (DataGrid)sender;
             DataRowView row_selected = gd.SelectedItem as DataRowView;
                if(row_selected!=null)
                {
                    txtCatogory.Text = row_selected["catogory"].ToString();
                    txtDescription.Text = row_selected["description"].ToString();
                    txtProductId.Text = row_selected["productID"].ToString();
                    txtUnitPrice.Text = row_selected["unitPrice"].ToString();
                    txtQuantity.Text = row_selected["quantity"].ToString();

                    pId = int.Parse(txtProductId.Text);
                    btnUpdate.IsEnabled = true;
                    btnDelete.IsEnabled = true;
                    Hidevisibilites();
                }
                    
        }
        
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Hidevisibilites();

            string p1 = txtCatogory.Text;
            string p2 = txtDescription.Text;
            string p3 = txtProductId.Text;
            string p4 = txtUnitPrice.Text;
            string p5 = txtQuantity.Text;

            RequiredValidation(p1, p2, p3, p4, p5);

            if(CanSubmit()==true)
            {
                using (SqlConnection con = new SqlConnection(cs))
                { 
                    string query = "Update Stock SET catogory='"+p1+ "',description='"+p2+ "',unitPrice="+decimal.Parse(p4)+ ",quantity="+ int.Parse(p5)+ " where productID="+pId+"";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery(); 
                }
                    fillDataGrid();
                    txtProductId.IsReadOnly = false;
                    txtCatogory.Text = "";
                    txtDescription.Text = "";
                    txtProductId.Text = "";
                    txtUnitPrice.Text = "";
                    txtQuantity.Text = "";

                    btnUpdate.IsEnabled = false;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM Stock WHERE productID="+pId;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
                fillDataGrid();
                txtProductId.IsReadOnly = false;
                txtCatogory.Text = "";
                txtDescription.Text = "";
                txtProductId.Text = "";
                txtUnitPrice.Text = "";
                txtQuantity.Text = "";
        }
    }
}
