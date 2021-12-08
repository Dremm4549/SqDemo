/*
* FILE          : MainWindow.cs
* PROJECT       : Seng2020 - milestone #4
* PROGRAMMER    : Max Pateman & Michael Dremo & Robert Socannder
* FIRST VERSION : 11/30/2021
* DESCRIPTION   : The main window is just to perform some basic logic for the demo how
*                 a buyer admin or planner might potentially log into the system with some preset usernames
*                 aswell as passwords
*              
*/

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
            BuyerObj b = new BuyerObj();

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
            else
            {
                MessageBox.Show("Error: The login infomation entered is incorrect. Please try again");
            }
        }
    }
}
