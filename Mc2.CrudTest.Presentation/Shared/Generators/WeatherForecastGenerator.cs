using System;
using System.Collections.Generic;
using System.Linq;

namespace Mc2.CrudTest.Domain.Generators
{
    public static class WeatherForecastGenerator
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public static List<WeatherForecast> GenerateWeatherForecast()
        {
            
            return Enumerable.Range(1, 15).Select((index) =>
                {
                    Random rng = new();
                    return new WeatherForecast()
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    };
                }).ToList();
        } 
    }
}