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
using System.Configuration;
using System.Data.SqlClient;

namespace MyPos
{
    /// <summary>
    /// Interaction logic for AdminAddUsersControl.xaml
    /// </summary>
    public partial class AdminAddUsersControl : UserControl
    {
        public AdminAddUsersControl()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string uname = txtName.Text;
            string password = txtPassword.Text;
            string userId = txtUserId.Text;
            string email = txtEmail.Text;
            string mobile = txtMobile.Text;
            string address = txtAddress.Text;
            

            string query = "INSERT INTO Users (userID,username,password,mobile,email,address) VALUES ('"+userId+"','"+uname+"','"+password+"','"+mobile+"','"+email+"','"+address+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
