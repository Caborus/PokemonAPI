using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("myController")]
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("Digimon")]

    public List<Digimon> GetDigimon(){
        List<Digimon> digimonList = new List<Digimon>();
        Digimon newDigimon = new Digimon(1, "Agumon", "Vaccine", "Rookie");
        digimonList.Add(newDigimon);
        return digimonList;
    }
}
