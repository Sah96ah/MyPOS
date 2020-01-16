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
using System.Data;
using System.Collections;
using System.Windows.Controls.Primitives;

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
            txtCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            clearAll();
            //filldataTable();
        }

        private int rowindex;//for deleting datagrid row

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        void fillCombo1()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT DISTINCT catogory FROM Stock";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
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
            txtTotal.Text = "";
            txtDiscount.Text = "";
        }

        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clearAll();
            //databind to cmbProductID
            if (cmbProduct.SelectedItem.ToString() == "")
            {
                productValidator.Visibility = Visibility.Visible;
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT DISTINCT productID FROM Stock WHERE catogory=@ct";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ct", cmbProduct.SelectedItem.ToString());
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
            //get description according to product id 
            //get unit price accoding to product id
            if (cmbProductID.SelectedIndex != -1)
            {
                int pId = int.Parse(cmbProductID.SelectedItem.ToString());
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT description, unitPrice FROM Stock WHERE productID=@pid";
                    cmd.Parameters.AddWithValue("@pid", pId.ToString());
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                       txtProductDes.Text = rd.GetValue(0).ToString();
                       txtUnitPrice.Text = rd.GetValue(1).ToString();
                    }
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
                decimal total = decimal.Parse(txtSubTotal.Text) - (dicper * decimal.Parse(txtSubTotal.Text)) / 100;
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
            //to check if any empty fields available
            if (txtDiscount.Text != "" || txtProductDes.Text != "" || txtQuality.Text != "" || txtTotal.Text != "" || txtUnitPrice.Text != ""
            || txtSubTotal.Text != "" || cmbProduct.SelectedIndex != -1 || cmbProductID.SelectedIndex != -1)
            {
                //set attribute for data grid class
                var data = new Grid { 
                    p1 = txtProductDes.Text,
                    p2 = txtUnitPrice.Text,
                    p3 = txtQuality.Text,
                    p4 = txtSubTotal.Text,
                    p5 = txtDiscount.Text,
                    p6 = txtTotal.Text,
                    p7 = int.Parse(cmbProductID.SelectedItem.ToString())};
                grdBillDetails.Items.Add(data);
                clearAll();
            }
        }
        
        //add bill to database
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string dt = DateTime.Now.ToString("MM/dd/yyyy");
            
            //bill number generator
            string dt2 = DateTime.Now.ToString();
            string date = Regex.Replace(dt2, @"[^0-9]", "");
            long bn = long.Parse(date);

            //get each cell values in datagrid
            for (int i = 0; i < grdBillDetails.Items.Count; i++)
            {
                //get each colomn value 
                TextBlock description = grdBillDetails.Columns[1].GetCellContent(grdBillDetails.Items[i]) as TextBlock;
                TextBlock unitPrice = grdBillDetails.Columns[2].GetCellContent(grdBillDetails.Items[i]) as TextBlock;
                TextBlock Quantity = grdBillDetails.Columns[3].GetCellContent(grdBillDetails.Items[i]) as TextBlock;
                TextBlock Subtotal = grdBillDetails.Columns[4].GetCellContent(grdBillDetails.Items[i]) as TextBlock;
                TextBlock Discount = grdBillDetails.Columns[5].GetCellContent(grdBillDetails.Items[i]) as TextBlock;
                TextBlock Total = grdBillDetails.Columns[6].GetCellContent(grdBillDetails.Items[i]) as TextBlock;
                TextBlock productId = grdBillDetails.Columns[0].GetCellContent(grdBillDetails.Items[i]) as TextBlock;

               
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Sales (billno,productID,description,unitprice,quantity,subtotal,discount,total,date) VALUES (@bn,@pid,@des,@up,@qu,@sub,@dis,@total,@dt)";
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@bn", bn);
                    cmd.Parameters.AddWithValue("@pid", int.Parse(productId.Text));
                    cmd.Parameters.AddWithValue("@des", description.Text);
                    cmd.Parameters.AddWithValue("@up", decimal.Parse(unitPrice.Text));
                    cmd.Parameters.AddWithValue("@qu", int.Parse(Quantity.Text));
                    cmd.Parameters.AddWithValue("@sub", decimal.Parse(Subtotal.Text));
                    cmd.Parameters.AddWithValue("@dis", decimal.Parse(Discount.Text));
                    cmd.Parameters.AddWithValue("@total", decimal.Parse(Total.Text));
                    cmd.Parameters.AddWithValue("@dt", dt);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        //delete row from grid 
        private void grdBillDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);
                if (row != null)
                {
                    btnAdd.IsEnabled = false;
                    rowindex = row.GetIndex();
                }
            }
        }
        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null) child = GetVisualChild<T>(v);
                if (child != null) break;
            }
            return child;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            grdBillDetails.Items.RemoveAt(rowindex);
            btnAdd.IsEnabled = true;
        }
    }

    //class which add items to database
    public class Grid
    {
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public string p4 { get; set; }
        public string p5 { get; set; }
        public string p6 { get; set; }
        public int p7 { get; set; }

    }
}
