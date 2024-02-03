using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_Generic_LINQ
{
    internal class ParmanentEmp : Employee, IEmployeeDetails<ParmanentEmp>
    {
        public double BasicSalary { get; set; }
        public double Allowance { get; set; }

        public override double CalculateSalary()
        {

            return BasicSalary + Allowance;
        }
        // Implement IEmployeeDetails Interface
        public void EmployeeDetails(ParmanentEmp emp)
        {
            Console.WriteLine($"Employee ID: {emp.EmpID}, Name: {emp.EmpName}, Department: {emp.Department}, " +
                $"Designation: {emp.Designation}, Basic Salary: {emp.BasicSalary}, Allowance: {emp.Allowance}, Payable Salary: {emp.CalculateSalary()}");
        }

    }
}
