using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DAL.Entities
{
     public class Employee :BaseEntity
    {
        public string Name { get; set; }

        public Department Department { get; set; }
    }
}
