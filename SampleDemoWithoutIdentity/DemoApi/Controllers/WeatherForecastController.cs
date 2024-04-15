using DemoApi.CommonModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var objCommonJson = new CommonJsonResponse();
            try
            {
                var i = 1;
                var x = 0;
                var testCalc = i / x;
                objCommonJson.result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
         .ToArray();
                objCommonJson.responseStatus = 1;
                objCommonJson.message = "Record found successfully.";

            }
            catch (Exception ex)
            {
                objCommonJson.responseStatus = 0;
                objCommonJson.message = ex.Message;
                if(ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    objCommonJson.message = ex.InnerException.Message;
                }
                //File logs for each error datetime wise 
                //store log in database
            }


            return Ok(objCommonJson);
        }
    }
}
