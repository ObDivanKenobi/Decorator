using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProvider
{
    public interface IWeatherProvider
    {
        WeatherInfo GetWeather(string city);
    }
}
