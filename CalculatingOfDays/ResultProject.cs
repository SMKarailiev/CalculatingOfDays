using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatingOfDays
{
    public class ResultProject
    {
        // EmployeeID of first employee.
        public int EmployeeID1 { get; set; }

        // EmployeeID of second employee.
        public int EmployeeID2 { get; set; }

        // ProjectID of the project in which they worked together.
        public List<int> ProjectIDS { get; set; }

        // TotalDays that they worked together.
        public int TotalDays { get; set; }

        // Constructor
        public ResultProject()
        {
            ProjectIDS = new List<int>();
        }
    }
}
