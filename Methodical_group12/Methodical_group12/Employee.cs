/*
* FILE          : Employee.cs
* PROJECT       : Seng2020 - milestone #4
* PROGRAMMER    : Max Pateman & Michael Dremo & Robert Socannder
* FIRST VERSION : 11/30/2021
* DESCRIPTION   : The employee file will represent attributes like name employee id
*                 department and etc to keep track of the current employee logged in and their
*                 role in the company.
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
    public class Employee
    {
        public int EmployeeID { set; get; }
        public string Surname { set; get; }
        public string FirstName { set; get; }
        public int Age { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Department { set; get; }

        public string OmniCorpStr = "server=localhost;user=root;database=omnicorp;port=3306;password=C4kd-s3d3-#ws090;";

    }
}
