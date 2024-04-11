using DataAccess.Models;
using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Azure;
using System.Reflection;
using DataAccess.ViewModel;
namespace DataAccess.Repository
{
    public class EmployeeService : IEmployeeInterface
    {

        public string ConnectionString { get; set; } = string.Empty;
        public EmployeeService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public EmployeeViewModel GetEmployees(string search = "", int page = 1, int pageSize = 20, string sortByColumn = "", string orderBy = "asc")
        {
            var objEmployeeViewModel = new EmployeeViewModel();
            var employeeLists = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "GetEmployees";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = conn;
                sqlCommand.Parameters.AddWithValue("@search", SqlDbType.NVarChar).Value = search;
                sqlCommand.Parameters.AddWithValue("@page", SqlDbType.NVarChar).Value = page;
                sqlCommand.Parameters.AddWithValue("@pageSize", SqlDbType.NVarChar).Value = pageSize;
                sqlCommand.Parameters.AddWithValue("@sortByColumn", SqlDbType.NVarChar).Value = sortByColumn;
                sqlCommand.Parameters.AddWithValue("@orderBy", SqlDbType.NVarChar).Value = orderBy;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                //sqlDataAdapter.SelectCommand = sqlCommand;
                //DataSet employeeDataset= new DataSet();
                //sqlDataAdapter.Fill(employeeDataset, "Employees");
                //sqlDataAdapter.Fill()
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    employeeLists.Add(
                        new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            City = reader["City"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString()
                            
                        }
                    );
                    objEmployeeViewModel.TotalRecord = Convert.ToInt32(reader["TotalRecords"]);
                }
                conn.Close();
            }
            objEmployeeViewModel.employees = employeeLists;
            return objEmployeeViewModel;
        }

        public int InsertEmployee(Employee model)
        {
            // Insert employee using ado.net 
            var returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "InsertEmployee";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = model.Name;
                sqlCommand.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = model.Email;
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = model.PhoneNumber;
                sqlCommand.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = model.City;
                sqlCommand.Connection = conn;
                //var name=(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input };
                //name.Value = model.Name;
                //sqlCommand.Parameters.Add);
                //sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Email", SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input });
                //sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@PhoneNumber", SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input });
                //sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@City", SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input });
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                returnvalue = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return returnvalue;

        }

      
    }
}
