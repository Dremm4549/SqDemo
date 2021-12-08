/*
* FILE          : Admin.xaml.cs
* PROJECT       : Seng2020 - milestone #4
* PROGRAMMER    : Max Pateman & Michael Dremo & Robert Socannder
* FIRST VERSION : 11/30/2021
* DESCRIPTION   : This file represents the code behind for the admin.
*                 Some functionalites that might go with it is altering files
*                 or tables
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
using System.Windows.Shapes;
using MySqlConnector;
using System.Net;
using System.IO;

namespace Methodical_group12
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    /// 

    /** class Admin
            brief Class to model Admins in the system. 

            This Admin class recieves access to many 
            administrative methods and files.
    */
    public class AdminObj : Employee
    {
        public string SecurityKey { set; get; }
        string TMSDataBaseIpAndPort = @"C:\Users\Michael\Desktop\sqproject\SqDemo\Methodical_group12\ConfigFiles\ConnInfo.txt";
        public string TMSconfigPath = @"C:\Users\Michael\Desktop\sqproject\SqDemo\Methodical_group12\ConfigFiles";

        /**
        * FUNCTION      : public string GetLogFiles(string selectedFile)
        *
        * DESCRIPTION   : returns the contents of an agreement within a contract
        *                 
        * PARAMETERS    : string selectedFile
        *
        * RETURNS       : String
        */
        public string GetLogFiles(string selectedFile)
        {
            
            return selectedFile;
        }

        /**
        * FUNCTION      : public string GetLogFiles(string selectedFile)
        *
        * DESCRIPTION   : returns th contents of an agreement within a contract
        *                 
        * PARAMETERS    : string selectedFile
        *
        * RETURNS       : String
        */
        public string GetConnInfo()
        {
            string tmpStr = "";
            try
            {
                //Read the text inside the conneciton file 
                tmpStr = File.ReadAllText(TMSDataBaseIpAndPort);
                char[] unwatedChar = { '\n', ':','\r' };
                string[] parsedData = tmpStr.Split(unwatedChar, StringSplitOptions.RemoveEmptyEntries);

                // TODO: parse the ip and port
                return tmpStr;

            }
            catch(Exception e)
            {
                tmpStr = e.Message;
            }
            

            return tmpStr;
        }

        /**
        * FUNCTION      : public string GetLogFiles(string selectedFile)
        *
        * DESCRIPTION   : Allow the admin to alter the contents in a long file to the connection
        *                 of the data base
        *                 
        * PARAMETERS    : string file
        *
        * RETURNS       : VOID
        */
        public void AlterInformation(string file)
        {
            //alters information in a log file
            //will take file, open and display through UI(?)
            
        }

        

        /**
        * FUNCTION      : public string GetLogFiles(string selectedFile)
        *
        * DESCRIPTION   : Allow the admin to alter the contents in a long file to the connection
        *                 of the data base
        *                 
        * PARAMETERS    : string file
        *
        * RETURNS       : VOID
        */
        public void AlterConnStr(string ip, string port)
        {
            //Read the text inside the conneciton file 
            string tmpStr;
            tmpStr = File.ReadAllText(TMSDataBaseIpAndPort);
            char[] unwatedChar = { '\n', ':', '\r' };
            string[] parsedData = tmpStr.Split(unwatedChar, StringSplitOptions.RemoveEmptyEntries);
            string error;

            //alters information in a log file
            try
            {
                IPAddress.Parse(ip);
                int tmpPort;
                bool isPortValid = int.TryParse(port, out tmpPort);
                if (isPortValid)
                {
                    tmpStr = tmpStr.Remove(tmpStr.IndexOf(":") + 1);
                    tmpStr += ip + "\r\n" + "Port:" + port;                   
                    try
                    {
                        File.WriteAllText(TMSDataBaseIpAndPort, tmpStr);
                    }
                    catch(IOException io)
                    {
                        //TODO Alert user of IO Message
                        error = io.Message;
                    }              
               }
            }
            catch (FormatException fe)
            {
                error = fe.Message;
            }
        }
    }



    public partial class Admin : Window
    {    
        AdminObj ao = new AdminObj();
        public Admin()
        {
            
            InitializeComponent();
            LoadDropDown(ao.TMSconfigPath);
        }

        /**
        * FUNCTION      :  public void LoadDropDown(string path)
        *
        * DESCRIPTION   : This function will populate all files inside the config file within the
        *                 the tms system
        *                 
        * PARAMETERS    : string path
        *
        * RETURNS       : NONE
        */

        public void LoadDropDown(string path)
        {
            if (Directory.Exists(path))
            {
                string[] fileNames = Directory.GetFiles(path);
                foreach(string fn in fileNames)
                {
                    string tmp;
                    tmp = System.IO.Path.GetFileName(fn);
                    cmb_ConfigOptions.Items.Add(tmp);
                }
            }
        }

        /**
        * FUNCTION      :  private void cmb_ConfigOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        *
        * DESCRIPTION   : This function will populate all files inside the config file within the
        *                 the tms system and will be used later to load the files so the admin can alter the files
        *                 
        * PARAMETERS    : string path
        *
        * RETURNS       : NONE
        */

        private void cmb_ConfigOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hideandPort();
            string selectedFile = cmb_ConfigOptions.SelectedItem.ToString();
            if(selectedFile == "ConnInfo.txt")
            {
                showIpAndPort();
            }
            
        }

        /**
        * FUNCTION      :  void hideandPort()
        *
        * DESCRIPTION   : Hides text boxes and lables 
        *                 
        * PARAMETERS    : string path
        *
        * RETURNS       : NONE
        */

        void hideandPort()
        {
            lbl_IP.Visibility = Visibility.Hidden;
            lbl_Port.Visibility = Visibility.Hidden;
            btn_Confirm_ipPort.Visibility = Visibility.Hidden;
            txt_Port.Visibility = Visibility.Hidden;
            txt_Ip.Visibility = Visibility.Hidden;
        }

        /**
        * FUNCTION      :  void showIpAndPort()
        *
        * DESCRIPTION   : Hides text boxes and lables 
        *                 
        * PARAMETERS    : string path
        *
        * RETURNS       : NONE
        */

        void showIpAndPort()
        {
            
            lbl_IP.Visibility = Visibility.Visible;
            lbl_Port.Visibility = Visibility.Visible;
            btn_Confirm_ipPort.Visibility = Visibility.Visible;
            txt_Port.Visibility = Visibility.Visible;
            txt_Ip.Visibility = Visibility.Visible;
        }

        /**
        * FUNCTION      :  private void btn_Confirm_ipPort_Click(object sender, RoutedEventArgs e)
        *
        * DESCRIPTION   : Allows the admin to change the connection string file
        *                 
        * PARAMETERS    : string path
        *
        * RETURNS       : NONE
        */
        private void btn_Confirm_ipPort_Click(object sender, RoutedEventArgs e)
        {
            ao.AlterConnStr(txt_Ip.Text,txt_Port.Text);
        }
    }
}
