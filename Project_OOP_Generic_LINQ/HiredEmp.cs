using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_Generic_LINQ
{
    internal class HiredEmp : Employee, IEmployeeDetails<HiredEmp>
    {
        public double HourlyRate { get; set; }
        public int WorkHrPerDay { get; set; }
        public int WorkDayPerMonth { get; set; }

        public override double CalculateSalary()
        {
            return HourlyRate * WorkHrPerDay * WorkDayPerMonth;
        }

        // Implement IEmployeeDetails Interface
        public void EmployeeDetails(HiredEmp emp)
        {
            Console.WriteLine($"Employee ID: {emp.EmpID}, Name: {emp.EmpName}, Department: {emp.Department}, " +
                $"Designation: {emp.Designation}, HourlyRate: {emp.HourlyRate}, WorkHourPerDay: {emp.WorkHrPerDay}," +
                $" WorkDayPerMonth: {emp.WorkDayPerMonth}, Payable Salary: {emp.CalculateSalary()}");
        }
    }
}
