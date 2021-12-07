using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Methodical_group12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            //AdminObj a = new AdminObj();
            //a.AlterConnStr(User.Text, test.Text);
            //a.GetConnInfo();
            BuyerObj b = new BuyerObj();

            //test.Text = b.InitiateContract();

            string password = psb_password.Password.ToString();
            string userID = User.Text;
            SignIn(userID, password);
        }

        void SignIn(string user, string pass)
        {
            if (user == "pDixon" && pass == "1234")
            {
                Planner plannerWindow = new Planner();
                plannerWindow.Show();
                this.Close();

            }
            else if (user == "bSally" && pass == "1")
            {
                Buyer buyerWindow = new Buyer();
                buyerWindow.Show();
                this.Close();
            }
            else if (user == "aBobby" && pass == "9101")
            {
                Admin adminrWindow = new Admin();
                adminrWindow.Show();
                this.Close();
            }
        }
    }
}
