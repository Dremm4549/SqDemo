using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodical_group12
{
    public class Employee
    {
        public int EmployeeID { set; get; }
        public string Surname { set; get; }
        public string FirstName { set; get; }
        public int Age { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Department { set; get; }

        public string OmniCorpStr = "server=localhost;user=root;database=omnicorp;port=3306;password=rootpass;";

    }
}
