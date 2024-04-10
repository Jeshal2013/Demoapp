using DataAccess.Models;
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
        List<Employee> GetEmployees();

    }

}
