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

namespace Methodical_group12
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    /// 

    ///class Admin
            ///brief Class to model Admins in the system. 

            ///This Admin class recieves access to many 
            ///administrative methods and files.
    ///
    public class AdminObj : Employee
    {
        string SecurityKey;

        ///
        /// FUNCTION      : public string GetLogFiles(string selectedFile)
        ///
        /// DESCRIPTION   : returns th contents of an agreement within a contract
        ///                 
        /// PARAMETERS    : string selectedFile
        ///
        /// RETURNS       : String
        ///
        public string GetLogFiles(string selectedFile)
        {
            return selectedFile;
        }

        ///
        /// FUNCTION      : public string GetLogFiles(string selectedFile)
        ///
        /// DESCRIPTION   : Allow the admin to alter the contents in a long file to the connection
        ///                 of the data base
        ///                 
        /// PARAMETERS    : string file
        ///
        /// RETURNS       : VOID
        ////
        public void AlterInformation(string file)
        {
            //alters information in a log file
        }
    }
    public partial class Admin : Window
    {    
        public Admin()
        {
            InitializeComponent();
        }

        internal void Open()
        {
            
        }
    }
}
