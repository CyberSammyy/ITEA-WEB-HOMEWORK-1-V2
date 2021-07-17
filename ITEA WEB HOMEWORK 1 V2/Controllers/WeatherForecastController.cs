using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEA_WEB_HOMEWORK_1_V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
        private static int idCounter = 0;
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
        public IEnumerable<WeatherForecast> Get()
        {
            //----------------------------------------------------------------------------------------------------------
            //THIS BLOCK OF CODE IS USED TO GENERATE ENTITIES AND JSON STRING TO PERFORM POST, PUT AND DELETE OPERATIONS
            //USE IT WHILE THE FIRST STARTUP ONLY BECAUSE IT BREAKS ID'S
            //----------------------------------------------------------------------------------------------------------
            //var rng = new Random(); 
            //var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            //int counter = 0;
            //foreach (var item in result)
            //{
            //    item.Id = counter;
            //    counter++;
            //}
            //weatherForecasts.AddRange(result);
            return weatherForecasts;
        }
        [HttpPost]
        public void Post(WeatherForecast forecast)
        {
            forecast.Id = idCounter++;
            weatherForecasts.Add(forecast);
        }
        [HttpPut] 
        public void Put(WeatherForecast forecast)
        {
            //for (int i = 0; i < weatherForecasts.Count; i++)
            //{
            //    if (weatherForecasts[i].Id == forecast.Id)
            //    {
            //        weatherForecasts[i] = forecast;
            //    }
            //}
            var result = weatherForecasts.FirstOrDefault(x => x.Id == forecast.Id);
            if(result != null)
            {
                result.Date = forecast.Date;
                result.Summary = forecast.Summary;
                result.TemperatureC = forecast.TemperatureC;
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            for(int i = 0; i < weatherForecasts.Count; i++)
            {
                if(weatherForecasts[i].Id == id)
                {
                    weatherForecasts.Remove(weatherForecasts[i]);
                }
            }
        }
    }
}
