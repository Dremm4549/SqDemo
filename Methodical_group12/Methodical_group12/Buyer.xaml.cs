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
        List<Contract> contractList = new List<Contract>();

        public string marketPlaceConnStr = "server=159.89.117.198;user=DevOSHT;database=cmp;port=3306;password=Snodgr4ss!;";


        /**
        * FUNCTION      : public int InitiateContract()
        *
        * DESCRIPTION   : This function will be used to get infromation from the marketplace randomly
        *                 since the marketplace refreshes every 10 seconds it will grab a random row
        *                 and concanate it into one string
        * 
        * PARAMETERS    : NONE
        *
        * RETURNS       : Contract
        */
        public string GetMarketPlaceInfo()
        {
            string tmpStr = "";
            int tmpQuantity;
            string tmpOrigin;
            string tmpDestination;
            int tmpJobType;
            int tmpVanType;
            string name = "";
            MySqlConnection conn = new MySqlConnection(marketPlaceConnStr);

            if(conn == null)
            {
                //TODO Write an error Message
            }

            try
            {             
                //TODO: create a mysql command to select a row at random in the contract market place table 
                // Once the row is selected extract things like client name quantity origin destination van type
                // into a new string which will be inserted into the contract database inside of tms
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM cmp.Contract;";
                conn.Open();
                

                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = reader.GetString("Client_Name").ToString();
                        tmpQuantity = reader.GetInt32("Quantity");
                        tmpJobType = reader.GetInt32("Job_Type");
                        tmpOrigin = reader.GetString("Origin").ToString();
                        tmpDestination = reader.GetString("Destination").ToString();
                        tmpVanType = reader.GetInt32("Van_Type");
                        Contract c = new Contract();

                        c.Client_Name = name;
                        c.Quantity = tmpQuantity;
                        c.JobType = tmpJobType;
                        c.Origin = tmpOrigin;
                        c.Destination = tmpDestination;
                        c.VanType = tmpVanType;
                        contractList.Add(c);
                    }
                }
                conn.Close();
                //Generate a number based on the amount of entries selected from mysql
                Random rnd = new Random();
                int generatedContract = rnd.Next(0, contractList.Count());

                tmpStr = contractList[generatedContract].Client_Name + "," + contractList[generatedContract].Quantity + ","
                    + contractList[generatedContract].Origin + "," + contractList[generatedContract].Destination + "," + contractList[generatedContract].JobType;      
            }
            catch(Exception e)
            {
                tmpStr = e.Message;
                // todo alert user of error
            }

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
            // TODO buyer may select relevant cities for the order if the city is in range.

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
            // Print origin & destination
            //Quantity
            // 

            Invoice inv = new Invoice();

            return inv;
        }
    }

    public partial class Buyer : Window
    {
        public string ContractStr { set; get; }
        BuyerObj buyer = new BuyerObj();
        public Buyer()
        {
            InitializeComponent();

            // TODO DISPLAY ALL Customers
            // GENERATE A LOG FILE FOR INVOICE
        }

        private void btn_InitiateContract_Click(object sender, RoutedEventArgs e)
        {
            //this method will allow Buyers to select a contract from the marketplace and will place an order with that 'customer'.
            ContractStr = buyer.GetMarketPlaceInfo();
            string retStr = InsertToContracts(ContractStr, buyer.marketPlaceConnStr);

        }
       
        string InsertToContracts(string data, string connStr)
        {
            string returnStr = "";
            string[] parsedData;
            char[] unwanteChar = { ',' };
            parsedData = data.Split(unwanteChar, StringSplitOptions.RemoveEmptyEntries);
            MySqlConnection conn = new MySqlConnection(buyer.econnStr);

            if (conn == null)
            {
                //TODO Write an error Message
            }

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert INTO contracts (ClientName,Quantity,Origin,Destination,Job_Type) values('" + parsedData[0] + "','" + parsedData[1] + "','" + parsedData[2] + "','" + parsedData[3] + "','" + parsedData[4] + "')";
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    returnStr = "Success: A contract has been inserted into the tms database";
                }
                catch (Exception e)
                {
                    returnStr = "Error: There has been an error trying to insert the contract. " + e.Message;
                }
            }
            catch (Exception msg)
            {
                returnStr = msg.Message;
            }
            conn.Close();
            return returnStr;
        }

        private void btn_InitiateOrder_Click(object sender, RoutedEventArgs e)
        {           
            lbl_StartDate.Visibility = Visibility.Visible;
            lbl_EndDate.Visibility = Visibility.Visible;
            txb_StartDate.Visibility = Visibility.Visible;
            txb_EndDate.Visibility = Visibility.Visible;
            btn_ConfirmOrder.Visibility = Visibility.Visible;           
        }

        string CreateOrder(string data, string connStr, string startDate, string endDate)
        {
            string returnStr = "";
            string[] parsedData;
            char[] unwanteChar = { ',' };
            parsedData = data.Split(unwanteChar, StringSplitOptions.RemoveEmptyEntries);

            MySqlConnection conn = new MySqlConnection(connStr);

            if (conn == null)
            {
                //TODO Write an error Message
            }

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert INTO orders (ClientName,Quantity,Origin,Destination,DateOfOrder,estimatedDeliveryDate) values('" + parsedData[0] + "','" + parsedData[1] + "','" + parsedData[3] + "','" + parsedData[4] + "','" + startDate + "','" + endDate +  "')";
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    returnStr = "Success: An order has been added to the data base";
                }
                catch (Exception e)
                {
                    returnStr = "Error: There has been an error trying to insert the contract. " + e.Message;
                }
            }
            catch (Exception msg)
            {
                returnStr = msg.Message;
            }
            conn.Close();

            return returnStr;
        }

        private void btn_Confirm_Order_Click(object sender, RoutedEventArgs e)
        {
            string tmpStartDate = txb_StartDate.Text;
            string tmpEndDate = txb_EndDate.Text;
            string RandomRow = buyer.GetMarketPlaceInfo();
            string retStr = CreateOrder(RandomRow, buyer.econnStr, tmpStartDate, tmpEndDate);
        }
    }


}


