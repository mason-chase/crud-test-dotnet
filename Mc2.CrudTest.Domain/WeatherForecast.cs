using System;
using System.Globalization;

namespace Mc2.CrudTest.Domain
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public override string ToString()
        {
            return $"Weather Forecast: [{nameof(Date)}: {Date.ToString(CultureInfo.CurrentCulture)}\n" +
                   $"{nameof(TemperatureC)}: {TemperatureC.ToString()}\n" +
                   $"{nameof(TemperatureF)}: {TemperatureF.ToString()}\n" +
                   $"{nameof(Summary)}: {Summary} ]";
        }
    }
}
