using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatingOfDays
{
    class ProjectWork
    {
        // EmployeeID of first employee.
        public int EmployeeID1 { get; set; }

        // EmployeeID of second employee.
        public int EmployeeID2 { get; set; }

        // ProjectID of the project in which they worked together.
        public int ProjectID { get; set; }
        
        //TotalDays that they worked together.
        public int TotalDays { get; set; }


        // Constructor
        public ProjectWork(int Employee1, int Employee2, int Project, int Days)
        {
            this.EmployeeID1 = Employee1;
            this.EmployeeID2 = Employee2;
            this.ProjectID = Project;
            this.TotalDays = Days;
        }

        // Constructor
        public ProjectWork()
        {
        }
    }
}
