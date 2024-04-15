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
        public CustomPageViewModel()
        {
            PageLists = new List<CommonOption>();
            PageLists.Add(new CommonOption { optionValue = "tytyty", optionText = "20" });
            PageLists.Add(new CommonOption { optionValue = "50", optionText = "50" });
            PageLists.Add(new CommonOption { optionValue = "100", optionText = "100" });
            PageLists.Add(new CommonOption { optionValue = "200", optionText = "200" });
        }
        public string search { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string orderBy { get; set; }
        public string sortBy { get; set; }
        public int TotalRecord { get; set; }
        public List<CommonOption> PageLists { get;set; }

        
    }
    public class CommonOption
    {
        public string optionText { get; set; }
        public string optionValue { get; set; }
    }

    public class EmployeeViewModel : CustomPageViewModel
    {
        public List<Employee> employees { get; set; }

    }
    
}
