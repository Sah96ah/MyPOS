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
            Hidevisibilites();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Hidevisibilites();
            
            //if(Chekuser()==false)
            //{
                string uname = txtName.Text;
                string password = txtPassword.Text;
                string userId = txtUserId.Text;
                string email = txtEmail.Text;
                string mobile = txtMobile.Text;
                string address = txtAddress.Text;
                string rePassword = txtRePassword.Text;

            //required field validation
            RequiredValidation(userId,uname,mobile,address, email, password, rePassword);
            
            if (passwordValidation(password,rePassword)==true && CanSubmit()==true)
            {
                    string query = "INSERT INTO Users (userID,username,password,mobile,email,address) VALUES ('" + userId + "','" + uname + "','" + password + "','" + mobile + "','" + email + "','" + address + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
            }
            else{
                    //some code here
            }
                
            //}
        }
        protected bool Chekuser()
        {
            
            string checkuser = "SELECT count(*) from Users where username='" + txtName.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                //LblErrorMsg.Visible = true;
                //LblMsg.Visible = false;
                return true;
            }

            return false;

        }

        protected void RequiredValidation(string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        {
       
            if (p1 == "")
                userIdValidator.Visibility = Visibility.Visible;                
            if (p2 == "")
                NameValidator.Visibility = Visibility.Visible;
            if (p3 == "")
                MobileNumberValidator.Visibility = Visibility.Visible;
            if (p4 == "")
                addressValidator.Visibility = Visibility.Visible;
            if (p5 == "")
                emailValidator.Visibility = Visibility.Visible;
            if (p6 == "")
                passwordValidator.Visibility = Visibility.Visible;
            if (p7 == "")
                repasswordValidator.Visibility = Visibility.Visible;
        }

        protected void Hidevisibilites()
        {
            userIdValidator.Visibility = Visibility.Hidden;
            NameValidator.Visibility = Visibility.Hidden;
            MobileNumberValidator.Visibility = Visibility.Hidden;
            addressValidator.Visibility = Visibility.Hidden;
            emailValidator.Visibility = Visibility.Hidden;
            passwordValidator.Visibility = Visibility.Hidden;
            repasswordValidator.Visibility = Visibility.Hidden;
        }
        
        protected bool CanSubmit()
        {
            if (userIdValidator.Visibility == Visibility.Hidden || 
                NameValidator.Visibility == Visibility.Visible || 
                MobileNumberValidator.Visibility == Visibility.Hidden ||
                addressValidator.Visibility == Visibility.Hidden ||
                emailValidator.Visibility == Visibility.Hidden ||
                passwordValidator.Visibility == Visibility.Hidden ||
                repasswordValidator.Visibility == Visibility.Hidden)
                return true;
            else
                return false;
        }

        protected bool passwordValidation(string p1, string p2)
        {

            if (p1 == p2)
            {
                passwordValidator.Visibility = Visibility.Hidden;
                repasswordValidator.Visibility = Visibility.Hidden;
                if (p1 == "" && p2 == "")
                {
                    passwordValidator.Visibility = Visibility.Visible;
                    repasswordValidator.Visibility = Visibility.Visible;
                    repasswordValidator.Content = "reqired";
                    return false;
                }
                else
                    return true;
            }
            else
            {
                passwordValidator.Visibility = Visibility.Hidden;
                repasswordValidator.Content = "Password are not matching";
                return false;
            }
                
        }
    }
    
}
