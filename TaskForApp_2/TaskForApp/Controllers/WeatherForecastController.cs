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
            //beklemeden di�er metodlar yaz�labilir

            var data = await myTask;
            return Ok(data);
        }
        [HttpGet]
        public  Task<string> GetTaskAsync()
        {
            //sadece asenkkron metod �al��t�r�caksan gerek yok asyn ve waite direk d�nebilirsin
            return new HttpClient().GetStringAsync("https://www.google.com");
        }
    }
}