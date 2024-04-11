using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
  public   interface IEmployeeInterface
    {
        int InsertEmployee(Employee model);
        EmployeeViewModel GetEmployees(string search = "", int page = 1, int pageSize = 20, string sortByColumn = "", string orderBy = "asc");

    }

}
