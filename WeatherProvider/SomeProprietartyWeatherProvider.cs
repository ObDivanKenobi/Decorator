using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProvider
{
    public sealed class SomeProprietartyWeatherProvider : IWeatherProvider
    {
        public SomeProprietartyWeatherProvider()
        {
            //very very secret... NOTHING
        }

        public WeatherInfo GetWeather(string city)
        {
            Random random = new Random();
            if (random.Next(2) % 2 == 0)
                throw new Exception();

            WeatherInfo info = new WeatherInfo();
            info = new WeatherInfo();
            info.CelsiusTemperature = 20;
            info.Weather = "Sunny";
            info.City = city;

            return info;
        }
    }
}
