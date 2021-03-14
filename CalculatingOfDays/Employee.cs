using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatingOfDays
{
    class Employee
    {
        // Employee ID.
        public int EmpId { get; set; }

        // Project ID.
        public int ProjectId { get; set; }

        // Started date of project.
        public DateTime DateFrom { get; set; }

        // Ended date of project.
        public DateTime DateTo { get; set; }


        // Constructor.
        public Employee(int EmpId, int ProjectId, DateTime DateFrom, DateTime DateTo)
        {
            this.EmpId = EmpId;
            this.ProjectId = ProjectId;
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
        }
    }
}
