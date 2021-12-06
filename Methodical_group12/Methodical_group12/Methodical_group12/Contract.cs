using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodical_group12
{

    /** \class Contract
    \brief Models a contract tied to an order.

    This class is used to represent order contracts.
    */
    public class Contract
    {
        public int ContractID { set; get; }
        public string BuyerSignature { set; get; }
        public string CustomerSignature { set; get; }
        public int OrderId { set; get; }

        /**
        * FUNCTION      : public string ContractAgreement(int contractID, string buyerSignature, string customerSignature, int orderID)
        *
        * DESCRIPTION   : returns th contents of an agreement within a contract
        *                 
        * PARAMETERS    : int contractID, string buyerSignature, string customerSignature, int orderID
        *
        * RETURNS       : String
        */
        public string ContractAgreement(int contractID, string buyerSignature, string customerSignature, int orderID)
        {
            string contractContents = "";
            return contractContents;
        }
    }
}
