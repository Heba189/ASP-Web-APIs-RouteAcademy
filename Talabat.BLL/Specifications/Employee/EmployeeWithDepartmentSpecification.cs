using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.BLL.Interfaces;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class EmployeeWithDepartmentSpecification : Specification<Employee>
    {

        public EmployeeWithDepartmentSpecification()
        {
            AddInclude(E => E.Department);
        }
    }
}
