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

        /**
        * FUNCTION      : public string SelectCarrier()
        *
        * DESCRIPTION   : Allow the planner to select carries for the order
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : NONE
        */

        public string SelectCarrier()
        {
            string tmpCarrier = "";

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
        public Planner()
        {
            InitializeComponent();
        }
    }

}
