using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Coursework
{
    internal class EmploymentStatus
    {
        public static List<EmploymentStatus> statuses = new List<EmploymentStatus>();
        public int StatusID { get; set; } // Primary key
        public string StatusDescription { get; set; } = ""; // Description shown to user

        public EmploymentStatus()
        {

        }

        public EmploymentStatus(int ID,  string StatusDescription)
        {
            StatusID = ID;
            this.StatusDescription = StatusDescription;
        }
        public void getlist()
        {
            
        }
    }
}
     