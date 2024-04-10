using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Vehical
    {
        public int VehicalId { get; set; }
        public string VehicalName { get; set; }
        public string VehicalNumber { get; set; }
        public int ModalYear { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}
