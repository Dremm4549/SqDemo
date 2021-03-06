/*
* FILE          : Invoice.cs
* PROJECT       : Seng2020 - milestone #4
* PROGRAMMER    : Max Pateman & Michael Dremo & Robert Socannder
* FIRST VERSION : 11/30/2021
* DESCRIPTION   : The invoice file is to model attributes that a invoice might be constructed of
*                 when creating one into a log file.
*              
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodical_group12
{

    /** \class Invoice
    \brief Class to model Invoice in the system. 

    This Invoice Class will represent all the attributes needed to create an Invoice
    for an Order
    */
    public class Invoice
    {
        int InvoiceID { set; get; }
        int BuyerID { set; get; }
        string BuyerSurName { set; get; }
        string BuyerLastName { set; get; }
        int CustomerID { set; get; }
        string CustomerSurName { set; get; }
        string CustomerLastName { set; get; }
        int OrderId { set; get; }
        string OrderAddress { set; get; }
    }
}
