using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_Generic_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;

            // ===================================Parmanent Employees List====================================
            List<ParmanentEmp> parmanentEmployees = new List<ParmanentEmp>()
            {
                new ParmanentEmp()
                {
                EmpID = "P-102",
                EmpName = "Mehedi",
                JoinDate = new DateTime(2023, 2, 2),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.JrDeveloper,
                BasicSalary = 15000,
                Allowance = 4000
                },
                new ParmanentEmp()
                {
                EmpID = "P-105",
                EmpName = "Rasel",
                JoinDate = new DateTime(2023, 01, 12),
                Department = Departments.IT,
                Designation = Designations.DataEntry,
                BasicSalary = 17000,
                Allowance = 5000
                },
                new ParmanentEmp()
                {
                EmpID = "P-107",
                EmpName = "Toha Z.",
                JoinDate = new DateTime(2022, 12, 20),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.SrDeveloper,
                BasicSalary = 35000,
                Allowance = 9000
                },
                new ParmanentEmp()
                {
                EmpID = "P-127",
                EmpName = "Arefin Y.",
                JoinDate = new DateTime(2023, 02, 08),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.SoftwareEngineer,
                BasicSalary = 45000,
                Allowance = 11000
                }
            };
            Console.WriteLine("\n======================================Parmanent Employee======================================");
            foreach (var emp in parmanentEmployees)
            {
                emp.EmployeeDetails(emp);
            }

            //==================================== Hired Employees List==================================
            List<HiredEmp> hiredEmployees = new List<HiredEmp>()
            {
                new HiredEmp()
                {
                EmpID = "H-902",
                EmpName = "Rakib",
                JoinDate = new DateTime(2023, 01, 01),
                Department = Departments.IT,
                Designation = Designations.SrDeveloper,
                HourlyRate = 250,
                WorkDayPerMonth = 20,
                WorkHrPerDay = 5
                },
                new HiredEmp()
                {
                EmpID = "H-916",
                EmpName = "Shourov Islam",
                JoinDate = new DateTime(2023, 01, 07),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.JrDeveloper,
                HourlyRate = 120,
                WorkDayPerMonth = 20,
                WorkHrPerDay = 8
                },
                new HiredEmp()
                {
                EmpID = "H-909",
                EmpName = "Kamal Raz",
                JoinDate = new DateTime(2023, 05, 10),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.SrDeveloper,
                HourlyRate = 300,
                WorkDayPerMonth = 20,
                WorkHrPerDay = 5
                }
            };
            Console.WriteLine("\n======================================Hired Employee======================================");
            foreach (var emp in hiredEmployees)
            {
                emp.EmployeeDetails(emp);
                
            }

            // ======================================Employees Leave Record============================================
            List<LeaveRecord> leaveRecords = new List<LeaveRecord>()
            {
                new LeaveRecord()
                {
                    EmpID = "P-105",
                    LeaveDate = new DateTime(2024,01, 02),
                    LeaveReason = "Sick",
                    LeaveCountDay = 1
                },
                new LeaveRecord()
                {
                    EmpID = "P-107",
                    LeaveDate = new DateTime(2024,01, 12),
                    LeaveReason = "Father's Sick",
                    LeaveCountDay = 3
                },
                new LeaveRecord()
                {
                    EmpID = "P-102",
                    LeaveDate = new DateTime(2024,01, 02),
                    LeaveReason = "Sick",
                    LeaveCountDay = 2
                }
            };
            Console.WriteLine("\n======================================Employee's Leave Records======================================");
            foreach(var leave in  leaveRecords)
            {
                Console.WriteLine($"EmployeeID: {leave.EmpID}, LeaveDate: {leave.LeaveDate}, Reason: {leave.LeaveReason}, TotalLeave: {leave.LeaveCountDay}");
            }

            // ------------------------Join Parmantnt Employee and Leave Record
            //                              Retrive Employees who have taken leave Using LINQ --------------
            var leaveEmployees = from pEmployees in parmanentEmployees
                                 join levRecord in leaveRecords
                                 on pEmployees.EmpID equals levRecord.EmpID
                                 select new
                                 {
                                     ID = pEmployees.EmpID,
                                     Name = pEmployees.EmpName,
                                     Depart = pEmployees.Department,
                                     Design = pEmployees.Designation,
                                     Date = levRecord.LeaveDate,
                                     Reason = levRecord.LeaveReason,
                                     TotalLeaveDay = levRecord.LeaveCountDay
                                 };
            Console.WriteLine("\n==========================Employees Leave Details================");
            foreach( var lv in leaveEmployees)
            {
                Console.WriteLine($"EmployeeID: {lv.ID}, Name: {lv.Name}, Department: {lv.Depart}, Designation: {lv.Design}, " +
                    $"LeaveDate: {lv.Date}, Reason: {lv.Reason}, TotalLeaveDay: {lv.TotalLeaveDay}");
            }

            // -----------------Retrive Employees Where Department = "SoftwareEngineering"  and Orderby() ID------------------
            Console.WriteLine("\n=========================Only SoftWare Engineering Department's Leave Record========================");
            var softDptLeaveCount = leaveEmployees.Where(emp => String.Equals(emp.Depart, Departments.SoftwareEngineering))
                .OrderByDescending(ord => ord.ID);

            foreach (var soft in softDptLeaveCount)
            {
                Console.WriteLine($"EmployeeID: {soft.ID}, Name: {soft.Name}, Department: {soft.Depart}, Designation: {soft.Design}, " +
                    $"LeaveDate: {soft.Date}, Reason: {soft.Reason}, TotalLeaveDay: {soft.TotalLeaveDay}");
            }




            Console.ReadKey();
        }
    }
}
