using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatingOfDays
{
    class CalculateDays
    {
        // This is a list of employees.
        private List<Employee> employees = new List<Employee>();

        // A constructor that loads the list from the text file.
        public CalculateDays(string filepath) 
        {
            string[] text = System.IO.File.ReadAllLines(filepath);
            foreach (var line in text)
            {
                var lineSplit = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // The value of lineSplit[3] is equal toDateTime, where compare to NULL,
                // if is NULL - we set it to current date, if not NULL - we get value of lineSplit[3] from the text file.
                if (lineSplit[3] == " NULL")
                {
                    employees.Add(new Employee(Convert.ToInt32(lineSplit[0]), Convert.ToInt32(lineSplit[1]), Convert.ToDateTime(lineSplit[2]), DateTime.Today));
                }
                else
                {
                    employees.Add(new Employee(Convert.ToInt32(lineSplit[0]), Convert.ToInt32(lineSplit[1]), Convert.ToDateTime(lineSplit[2]), Convert.ToDateTime(lineSplit[3])));

                }
            }
        }

        // Calculates the biggest timespan of two employees working on a same project.
        public void CalculateTimeSpan() 
        {
            int timespan = 0;
            var WorkedTogether = new List<ProjectWork>();
            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = i; j < employees.Count; j++)
                {
                    if (employees[i].EmpId != employees[j].EmpId && employees[i].ProjectId == employees[j].ProjectId && employees[i].DateTo > employees[j].DateFrom && employees[j].DateTo > employees[i].DateFrom)
                    {
                        timespan = CalculateRange(employees[i].DateFrom, employees[i].DateTo, employees[j].DateFrom, employees[j].DateTo);

                        WorkedTogether.Add(new ProjectWork(employees[i].EmpId, employees[j].EmpId, employees[i].ProjectId, timespan));
                    }
                }
            }

            // Creating a new list and set values of the properties and grouping using LINQ. 
            var result = WorkedTogether.GroupBy(x => new { x.EmployeeID1, x.EmployeeID2, x.TotalDays, x.ProjectID })
                                       .Select(w => new ProjectWork()
                                       {
                                           EmployeeID1 = w.Key.EmployeeID1,
                                           EmployeeID2 = w.Key.EmployeeID2,
                                           TotalDays = w.Sum(d => d.TotalDays),
                                           ProjectID = w.Key.ProjectID
                                       }
                                       ).OrderByDescending(w => w.TotalDays).ToList().First();

            Console.Write("\nEmployees who worked together:");
            Console.WriteLine("\nEmployee ID 1:" + result.EmployeeID1 + "\nEmployee ID 2:" + result.EmployeeID2 + "\nTotal days together:" + result.TotalDays + "\nProject ID:" + result.ProjectID);
            Console.ReadLine();
        }

        // Calculates the timespan. 
        public int CalculateRange(DateTime DateFrom1, DateTime DateTo1, DateTime DateFrom2, DateTime DateTo2)
        {
            double timespan = 0;
            if (DateFrom1 <= DateFrom2 && DateTo1 <= DateTo2)
            {
                timespan = (DateTo1 - DateFrom2).TotalDays;
            }
            else if (DateFrom1 <= DateFrom2 && DateTo1 >= DateTo2)
            {
                timespan = (DateTo2 - DateFrom2).TotalDays;
            }
            else if (DateFrom1 >= DateFrom2 && DateTo1 <= DateTo2)
            {
                timespan = (DateTo1 - DateFrom1).TotalDays;
            }
            else if (DateFrom1 >= DateFrom2 && DateTo1 >= DateTo2)
            {
                timespan = (DateTo2 - DateFrom1).TotalDays;
            }
            return (int)timespan;
        }
    }
}
