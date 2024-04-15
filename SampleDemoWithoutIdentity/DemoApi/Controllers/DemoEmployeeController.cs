using DataAccess.Services;
using DemoApi.CommonMethods;
using DemoApi.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoEmployeeController : ControllerBase
    {
        // GET: api/<DemoEmployeeController>

        IEmployeeInterface employeeService;
        public DemoEmployeeController( IEmployeeInterface employeeInterface)

        {
            employeeService = employeeInterface;
        }




        [HttpGet]
        public ActionResult Get(string search = "", int page = 1, string sortby = "Name", string orderBy = "asc", int pageSize = 20)
        {

            var objCommonJson = new CommonJsonResponse();
            try
            {
                var objEmployeeLists = employeeService.GetEmployees(search, page, pageSize, sortByColumn: sortby, orderBy: orderBy);
                objCommonJson.page = page;
                objCommonJson.responseStatus = 1;
                if (objEmployeeLists!=null && objEmployeeLists.TotalRecord > 0)
                {
                    objCommonJson.message = "Record found successfully.";
                    objCommonJson.totalRecord = objEmployeeLists.TotalRecord;
                }
                else
                {
                    objCommonJson.responseStatus = 2;
                    objCommonJson.message = "No record found as per request search value";
                }
                objCommonJson.result = objEmployeeLists.employees;

            }
            catch (Exception ex)
            {
                objCommonJson.responseStatus = 0;
                objCommonJson.message = ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    objCommonJson.message = ex.InnerException.Message;
                }
                CommonFunction.WriteMessage(objCommonJson.message);
                //File logs for each error datetime wise 
                //store log in database
            }


            return Ok(objCommonJson);
        }

        // GET api/<DemoEmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DemoEmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DemoEmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DemoEmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
