using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP_Generic_LINQ
{
    internal interface IEmployeeDetails<T>
    {
        void EmployeeDetails(T emp);
    }
}
