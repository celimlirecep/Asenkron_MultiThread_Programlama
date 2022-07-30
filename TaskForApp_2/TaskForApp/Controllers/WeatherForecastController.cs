using Microsoft.AspNetCore.Mvc;

namespace TaskForApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var myTask = new HttpClient().GetStringAsync("https://www.google.com");
            //beklemeden diðer metodlar yazýlabilir

            var data = await myTask;
            return Ok(data);
        }
        [HttpGet]
        public  Task<string> GetTaskAsync()
        {
            //sadece asenkkron metod çalýþtýrýcaksan gerek yok asyn ve waite direk dönebilirsin
            return new HttpClient().GetStringAsync("https://www.google.com");
        }
    }
}