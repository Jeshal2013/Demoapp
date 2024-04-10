using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class VehicalViewModal
    {
        public int VehicalId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string VehicalName { get; set; }
        public string VehicalNumber { get; set; }
        public int ModalYear { get; set; }
        public string Description { get; set; }
    }
}
