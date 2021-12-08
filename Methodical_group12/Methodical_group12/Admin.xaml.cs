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
using System.IO;
using System.Net;

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
        string TMSDataBaseConnectionFilepath = @"ConnInfo.txt";

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
                tmpStr = File.ReadAllText(TMSDataBaseConnectionFilepath);
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
            tmpStr = File.ReadAllText(TMSDataBaseConnectionFilepath);
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
                        File.WriteAllText(TMSDataBaseConnectionFilepath, tmpStr);
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
        public Admin()
        {
            
            InitializeComponent();
        }

        private void btn_OpenLog_Click(object sender, RoutedEventArgs e)
        {
            txt_Log.Text = File.ReadAllText("C:\\Test\\LogForM4.txt");
        }

        private void txt_Directory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
