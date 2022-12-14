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
            //beklemeden diğer metodlar yazılabilir

            var data = await myTask;
            return Ok(data);
        }
        [HttpGet]
        public  Task<string> GetTaskAsync()
        {
            //sadece asenkkron metod çalıştırıcaksan gerek yok asyn ve waite direk dönebilirsin
            return new HttpClient().GetStringAsync("https://www.google.com");
        }
    }
}