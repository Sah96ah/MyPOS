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
        private int rowindex;
        Returninfo info = new Returninfo();

        //clear all text field values 
        private void clearAll()
        {
            txtQuantityReturn.Text = "";
        }

        //find product information
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            long bno = long.Parse(txtbillNo.Text);
           
            //retrive bill information
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT description,unitprice,quantity,subtotal,discount,productID,date FROM Sales WHERE billno=@bn";
                cmd.Parameters.AddWithValue("@bn", bno);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Bill");
                sda.Fill(dt);
                grdBill.ItemsSource = dt.DefaultView;
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

        //add to gridview
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //to check if any empty fields available
            if (txtbillNo.Text != "")
            {

                //set attribute for data grid class
                var data = new Grid2 {
                    p1 = info.p1,
                    p2 = info.p2,
                    p3 = int.Parse(txtQuantityReturn.Text),
                    p4 = info.p4,
                    p5 = info.p5 / info.p3 * decimal.Parse(txtQuantityReturn.Text)
                };

                grdReturnDetails.Items.Add(data);
                clearAll();
            }
        }

        //for deletion
        private void grdReturnDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        //remove from data grid 
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            grdReturnDetails.Items.RemoveAt(rowindex);
            btnAdd.IsEnabled = true;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            //add return details to database
            string dt = DateTime.Now.ToString("MM/dd/yyyy");
            string date = Regex.Replace(dt, @"[^0-9]", "");
            long bn = long.Parse(txtbillNo.Text);

            //get each cell values in datagrid
            for (int i = 0; i < grdReturnDetails.Items.Count; i++)
            {
                //get each colomn value 
                TextBlock description = grdReturnDetails.Columns[1].GetCellContent(grdReturnDetails.Items[i]) as TextBlock;
                TextBlock unitPrice = grdReturnDetails.Columns[2].GetCellContent(grdReturnDetails.Items[i]) as TextBlock;
                TextBlock Quantity = grdReturnDetails.Columns[3].GetCellContent(grdReturnDetails.Items[i]) as TextBlock;
                TextBlock total = grdReturnDetails.Columns[4].GetCellContent(grdReturnDetails.Items[i]) as TextBlock;
                TextBlock productId = grdReturnDetails.Columns[0].GetCellContent(grdReturnDetails.Items[i]) as TextBlock;


                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO SalesReturn (billno, productID, description,quantity,amountreturn,date) VALUES (@bn,@pid,@des,@qu, @total,@dt)";

                    cmd.Parameters.AddWithValue("@bn", long.Parse(txtbillNo.Text));
                    cmd.Parameters.AddWithValue("@pid", int.Parse(productId.Text));
                    cmd.Parameters.AddWithValue("@des", description.Text);
                    cmd.Parameters.AddWithValue("@qu", int.Parse(Quantity.Text));
                    cmd.Parameters.AddWithValue("@total", decimal.Parse(total.Text));
                    cmd.Parameters.AddWithValue("@dt", dt);


                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            //delete detalis from Sales

            //add to stock
        }

        private void grdBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtDate.Text = row_selected["date"].ToString();
                //txtTotal.Text = row_selected["subtotal"].ToString();
                //txtDescription.Text = row_selected["description"].ToString();
                //txtProductID.Text = row_selected["productID"].ToString();
                //txtUnitPrice.Text = row_selected["unitPrice"].ToString();
                //txtQuantity.Text = row_selected["quantity"].ToString();

                info.p1 = int.Parse(row_selected["productID"].ToString());
                info.p2 = row_selected["description"].ToString();
                info.p3 = int.Parse(row_selected["quantity"].ToString());
                info.p4 = decimal.Parse(row_selected["unitPrice"].ToString());
                info.p5 = decimal.Parse(row_selected["subtotal"].ToString());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }

    //
    public class Returninfo
    {
        public int p1 { get; set; }
        public string p2 { get; set; }
        public int p3 { get; set; }
        public decimal p4 { get; set; }
        public decimal p5 { get; set; }
    }
    //add details to grid 
    public class Grid2
    {
        public int p1 { get; set; }
        public string p2 { get; set; }
        public int p3 { get; set; }
        public decimal p4 { get; set; }
        public decimal p5 { get; set; }
    } 
}


