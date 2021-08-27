using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApiOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IInMemoryDb _inMemoryDb;

        public WeatherForecastController(IInMemoryDb inMemoryDb)
        {
            _inMemoryDb = inMemoryDb;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = _inMemoryDb.Summaries[rng.Next(_inMemoryDb.Summaries.Count())]
            })
            .ToArray();
        }

    }
}
