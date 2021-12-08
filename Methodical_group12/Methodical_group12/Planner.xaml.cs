/*
* FILE          : Planner.xaml.cs
* PROJECT       : Seng2020 - milestone #4
* PROGRAMMER    : Max Pateman & Michael Dremo & Robert Socannder
* FIRST VERSION : 11/30/2021
* DESCRIPTION   : The planner file will allow functionality for the user to change the status 
*                 of orders increment the current time of the order wether to compare if it has met its
*                 expected delivery date if so it will be marked as completed. 
*              
*/

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
        public int orderID { set; get; }
        public int NumOfContracts { set; get; }
        public int PlannerEmpID { set; get; }

        /**
        * FUNCTION      : public string CarrierAssign()
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

        public string SimulateTime()
        {
            string retStr = "";

            return retStr;
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
            MySqlConnection newConnection = new MySqlConnection("dsad");
            //ensure that all aspects of order are properly set and mark for follow-up
            if (newConnection == null)
            {

            }
            else
            {
                try
                {
                    MySqlCommand cmd = newConnection.CreateCommand();

                    //get any contract that has a NULL status (inactive).
                    cmd.CommandText = "SELECT * FROM omnicorp.orders where OrderStatus is null and Carrier is null;";
                    newConnection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                        }

                    }
                }
                catch (Exception e)
                {
                    
                }
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
        List<Order> o = new List<Order>();
        Order tmpOrder = new Order();
        string connStr;

        public Planner()
        {
            InitializeComponent();
        }

        private void btn_GenerateOrder_Click(object sender, RoutedEventArgs e)
        {
            //refresh list of orders

            //ensure that all aspects of order are properly set and mark for follow-up
            lbx_Orders.Items.Clear();
            string orders = GetInactiveOrders(newPlanner.OmniCorpStr);
            string commandReturn = orders.Remove(orders.IndexOf(":"));

            if (commandReturn == "Success")
            {
                //Iterate through the list appending to the box
                string clientInfo = "";
                foreach (Order order in o)
                {
                    clientInfo = order.orderID + "," + order.ClientName + "," + order.OrderStatus;
                    lbx_Orders.Items.Add(clientInfo);
                    
                }

            }
            else
            {
                MessageBox.Show(commandReturn);
            }

        }

        private void btn_SelectCarrier_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lbx_Orders_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            //dropdown box will update when an initiated order has been chosen. 
            cbx_CarrierSelect.Items.Add("carrier");

        }

        private void btn_Summary_Click(object sender, RoutedEventArgs e)
        {
            //populate list with orders with the status of 'active'
            // for (iterate through orders table) {
            //  ordersList[0] = "Order is this | Status is this \n";
            // }
            //should show status screen with all active orders (listed) (orderStatus=active)

            OrderSummary orderSummary = new OrderSummary();
            orderSummary.Show();

        }

        private void btn_Trips_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListBoxItem_GotFocus(object sender, RoutedEventArgs e)
        {
            // Output text box to set status of order
        }

        public string GetInactiveOrders(string connectStr)
        {
            connStr = connectStr;
            MySqlConnection conn = new MySqlConnection(connStr);
            string retString = "";
            string tmpClientName = "";
            int tmpOrderID;
            string tmpStatus = "";
            string tmpCarrier = "";

            string tmpOrderDate = "";
            string tmpOrigin = "";
            string tmpDestination = "";
            string tmpEstDeliveryDate = "";


            if (conn == null)
            {
                retString = "Error: There was an issue connecting to the database";
            }
            else
            {
                MySqlCommand cmd = conn.CreateCommand();
                o.Clear();
                //get any order that has a NULL status (inactive).
                cmd.CommandText = "select * From omnicorp.orders where OrderStatus = 'inactive' and Carrier = 'Undefined';";
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // get location from relevant order.
                            //take info from contract table.
                            tmpClientName = reader.GetString("ClientName").ToString();
                            tmpOrderID = reader.GetInt32("OrderNumber");
                            tmpStatus = reader.GetString("OrderStatus").ToString();
                            tmpCarrier = reader.GetString("Carrier").ToString();

                            tmpOrderDate = reader.GetString("DateOfOrder").ToString();
                            tmpOrigin = reader.GetString("Origin").ToString();
                            tmpDestination = reader.GetString("Destination").ToString();
                            tmpEstDeliveryDate = reader.GetString("estimatedDeliveryDate").ToString();

                            tmpOrder.orderID = tmpOrderID;
                            tmpOrder.OrderStatus = tmpStatus;
                            tmpOrder.ClientName = tmpClientName;
                            tmpOrder.Carrier = tmpCarrier;

                            tmpOrder.OrderDate = tmpOrderDate;
                            tmpOrder.Origin = tmpOrigin;
                            tmpOrder.Destination = tmpDestination;
                            tmpOrder.EstDeliveryDate = tmpEstDeliveryDate;
                            o.Add(tmpOrder);
                        }
                        retString = "Success: Orders Refreshed";
                    }
                }
                catch (Exception exp)
                {
                    retString = "Error: " + exp.Message;
                }
                conn.Close();
            }

            return retString;
        }

        private void lbx_Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            // When the planner selects an item check if its inactive if so display allow them

            // To modify the carrier
            MySqlCommand cmd = conn.CreateCommand();
            //get any contract that has a NULL status (inactive).
            cmd.CommandText = "select DISTINCT CarrierName From omnicorp.orders where OrderStatus is '"+ tmpOrder.Origin +"';";
            conn.Open();
            List<string> carrierList = new List<string>();
            try
            {
                //open connection and read the 
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            newPlanner.ConfirmOrder();
        }
    }
}
