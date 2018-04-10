using WeatherProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Decorator
{
    public class RetryingWeatherProvider : IWeatherProvider
    {
        private readonly IWeatherProvider _provider;
        private readonly int _waitingTime;
        private readonly int _maxTries;

        public IWeatherProvider InnerObject => _provider;

        public RetryingWeatherProvider(IWeatherProvider provider, int maxTries, int waitingTime)
        {
            _provider = provider;
            _maxTries = maxTries;
            _waitingTime = waitingTime;
        }

        public WeatherInfo GetWeather(string city)
        {
            int retries = 0;
            WeatherInfo info = null;
            do
            {
                try
                {
                    info = _provider.GetWeather(city);
                }
                catch (Exception)
                {
                    if (retries == _maxTries)
                        throw;
                    else
                        Thread.Sleep(_waitingTime);
                }
            } while (++retries <= _maxTries);

            return info;
        }
    }
}
