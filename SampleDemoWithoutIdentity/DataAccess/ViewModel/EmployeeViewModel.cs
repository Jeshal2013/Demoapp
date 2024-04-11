using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class CustomPageViewModel
    {
        public string search { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string orderBy { get; set; }
        public string sortBy { get; set; }
        public int TotalRecord { get; set; }
    }

    public class EmployeeViewModel : CustomPageViewModel
    {
        public List<Employee> employees { get; set; }
    }
}
