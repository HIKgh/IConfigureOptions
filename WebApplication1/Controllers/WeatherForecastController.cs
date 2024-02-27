using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace WebApplication1.Controllers
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
        private PersonSettings _personSettings;
        private readonly SlackApiSettings _slackApiSettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOptionsMonitor<PersonSettings> personOptionsMonitor,
            IOptions<PersonSettings> personOptions,
            IOptionsSnapshot<SlackApiSettings> slackApiOptions)
        {
            _logger = logger;
            _personSettings = personOptionsMonitor.CurrentValue;
            personOptionsMonitor.OnChange(newValue => _personSettings = newValue);
            var personSettings = personOptions.Value;
            _slackApiSettings = slackApiOptions.Get("Dev");
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
