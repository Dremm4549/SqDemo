using MySql.Data.MySqlClient;
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
    /// Interaction logic for Planner.xaml
    /// </summary>
    /// 

    /** \class PlannerObj
    \brief Class to model Planners in the system.

    This class allows planners to execute their 
    piece of functionality within the TMS system.
    */

    public class PlannerObj : Employee
    {
        public string ConnStr = "server=localhost;port=3306;user=root;password=rootpass;database=omnicorp;";
        public int orderID { set; get; }

        string OrderDate;
        string Origin;
        string ClientName;
        string EstDeliveryDate;
        string Carrier;
        string Status;
        int Quantity;

        /**
        * FUNCTION      : public string SelectCarrier()
        *
        * DESCRIPTION   : Allow the planner to select carries for the order
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : NONE
        */

        public string CarrierAssign (string tempCarrier)
        {
            //parameter should come from cbx_carrierSelect
            string tmpCarrier = tempCarrier;
            //if Carrier exists, 
            

            return tmpCarrier;
        }

        /**
        * FUNCTION      : public int SimulateTime()
        *
        * DESCRIPTION   : Allows the user to simulate tim passed on an order
        *                 will then return the number of the entered time.
        * PARAMETERS    : NONE
        *
        * RETURNS       : NONE
        */

        public int SimulateTime()
        {
            int tmpSimulatedTime = 0;

            return tmpSimulatedTime;
        }

        /**
        * FUNCTION      : public int ConfirmOrder()
        *
        * DESCRIPTION   : Confirms that the order is created then inserted into the database
        * PARAMETERS    : NONE
        *
        * RETURNS       : NONE
        */

        public void ConfirmOrder()
        {
            //ensure that all aspects of order are properly set and mark for follow-up
            if (ConnStr == null)
            {

            }
            else
            {
                MySqlConnection newConnection = new MySqlConnection(ConnStr);
                MySqlCommand cmd = newConnection.CreateCommand();

                //get any contract that has a NULL status (inactive).
                cmd.CommandText = "SELECT OrderID FROM omnicorp.orders WHERE OrderStatus is NULL;";
                newConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // get location from relevant order.

                        //take info from contract table.
                        //orderID = reader.GetInt32("OrderNumber");
                        //OrderDate = reader.GetString("DateOfOrder");
                        //Origin = reader.GetString("Origin");
                        //ClientName = reader.GetString("ClientName");
                        //EstDeliveryDate = reader.GetString("estimatedDeliveryDate");
                        //Carrier = reader.GetString("Carrier");
                        //Status = reader.GetString("OrderStatus");
                        //Quantity = reader.GetInt32("Quantity");
                    }
                    
                }

                // compare to contracts and their available locations (same method.)

                // This will allow the drop-down list to be appended to.
            }
        }

        /**
        * FUNCTION      : public int CheckActiveOrders()
        *
        * DESCRIPTION   : select all orders that currently active in the database and
        *                 return a number of active orders
        * PARAMETERS    : NONE
        *
        * RETURNS       : NONE
        */

        public int CheckActiveOrders()
        {
            
            int tmpActiveOrders = 0;

            return tmpActiveOrders;
        }
    }
    public partial class Planner : Window
    {
        PlannerObj newPlanner = new PlannerObj();
        public Planner()
        {
            InitializeComponent();
            //newPlanner.newConnection.Open(ConnStr);
        }

        private void btn_GenerateOrder_Click(object sender, RoutedEventArgs e)
        {
            //refresh list of orders

        }

        private void btn_SelectCarrier_Click(object sender, RoutedEventArgs e)
        {
            //clicking the 'select Carrier' button will check the textbox for a valid input and assign carriers.
            
        }

        private void lbx_Orders_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            //dropdown box will update when an initiated order has been chosen. 

            //foreach (carrier in selectedLocation) {
            cbx_CarrierSelect.Items.Add("carrier");
            //}
        }

        private void btn_Summary_Click(object sender, RoutedEventArgs e)
        {
            string[] ordersList;
            //populate list with orders with the status of 'active'
            // for (iterate through orders table) {
            //  ordersList[0] = "Order is this | Status is this \n";
            // }
            //should show status screen with all active orders (listed) (orderStatus=active)
        }

        private void btn_Trips_Click(object sender, RoutedEventArgs e)
        {
            newPlanner.ConfirmOrder();
        }
    }

}
