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
            fillCombo2();
            txtCurrentDate.Text = DateTime.Now.ToShortDateString();
        }
        void fillCombo1()
        {
            //sample test to combo 
            cmb1.Items.Add("pen");
            cmb1.Items.Add("paper");
            cmb1.Items.Add("pen112");
            cmb1.Items.Add("paper13");
            cmb1.Items.Add("pen13");
            cmb1.Items.Add("paper1313");
            cmb1.Items.Add("pen12312");
            cmb1.Items.Add("pen132");
            cmb1.Items.Add("paper13");
            cmb1.Items.Add("paper131");

        }

        void fillCombo2()
        {
            cmb2.Items.Add(1);
            cmb2.Items.Add(2);
            cmb2.Items.Add(3);
            cmb2.Items.Add(4);
            cmb2.Items.Add(5);

        }
    }
}
