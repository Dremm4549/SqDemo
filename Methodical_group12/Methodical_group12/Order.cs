using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodical_group12
{

    /** \class Order
    \brief Models a contract tied to an order.

    This class is used to represent a customer's
    order in the TMS system.
    */
    public class Order
    {
        public int orderID { set; get; }
        string OrderStatus { set; get; }

        /**
        * FUNCTION      : public string CurrentOrderStatus()
        *
        * DESCRIPTION   : Returns the order status of the order object
        *                 
        * PARAMETERS    : NONE
        *
        * RETURNS       : String
        */

        public string CurrentOrderStatus()
        {
            string tmpOrderStatus = "";

            return tmpOrderStatus;
        }
    }
}
