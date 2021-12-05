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

namespace Methodical_group12
{
    /// <summary>
    /// Interaction logic for Buyer.xaml
    /// </summary>
    /// 

    public class BuyerObj : Employee
    {
        public int BuyerID { set; get; }
        public int NumberOfOrders { set; get; }
        public int NumberOfContracts { set; get; }


        /**
        * FUNCTION      : public int InitiateContract()
        *
        * DESCRIPTION   : This function will generate a Contract Object that will
        *                 create a contract object.
        * 
        * PARAMETERS    : NONE
        *
        * RETURNS       : Contract
        */
        public string InitiateContract()
        {
            string tmpStr = "";


            return tmpStr;
        }

        /**
        * FUNCTION      : public int InitiateContract()
        *
        * DESCRIPTION   : Allows the user to simulate tim passed on an order
        *                 will then return the number of the entered time.
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : string
        */

        public string GetExistingCustomers()
        {
            string customerInformation = "";

            return customerInformation;
        }

        /**
        * FUNCTION      : public Order InitiateNewOrder()
        *
        * DESCRIPTION   : Will create an object order. The buyer will be asked 
        *                 to pass arguments based on what ever is needed to create an order
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : Order
        */

        public Order InitiateNewOrder()
        {
            Order oObj = new Order();

            return oObj;
        }

        /**
        * FUNCTION      : public int GetCompletedOrder()
        *
        * DESCRIPTION   : Will create an object order. The buyer will be asked 
        *                 to pass arguments based on what ever is needed to create an order
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : Order
        */

        public int GetCompletedOrder()
        {
            int completedOrders = 0;

            return completedOrders;
        }

        /**
        * FUNCTION      : public string SelectOrderCities()
        *
        * DESCRIPTION   : Select city that order will be sent to
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : Order
        */

        public string SelectOrderCities()
        {
            string tmpOrderCitites = "";

            return tmpOrderCitites;
        }

        /**
        * FUNCTION      : public Invoice GenerateInvoice()
        *
        * DESCRIPTION   : This will create an invoice object that will be sent to the omnicorp database
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : Invoice
        */

        public Invoice GenerateInvoice()
        {
            Invoice inv = new Invoice();

            return inv;
        }
    }

    public partial class Buyer : Window
    {
        public Buyer()
        {
            InitializeComponent();
        }
    }
}
