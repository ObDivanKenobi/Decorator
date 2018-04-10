using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProvider;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            int tries = 5;
            SomeProprietartyWeatherProvider provider = new SomeProprietartyWeatherProvider();
            RetryingWeatherProvider decorated = new RetryingWeatherProvider(provider, 5, 0);
            string city = "SomeCity";

            bool baseProviderFailed = false,
                decoratorSucceeded = false;

            while(!baseProviderFailed & !decoratorSucceeded)
            {
                try
                {
                    provider.GetWeather(city);
                    baseProviderFailed = false;
                }
                catch
                {
                    baseProviderFailed = true;
                }

                try
                {
                    decorated.GetWeather(city);
                    decoratorSucceeded = true;
                }
                catch
                {
                    decoratorSucceeded = false;
                }
            }

            Console.WriteLine("Not decorated provider failed.");
            Console.WriteLine("Decorated provider succeeded!");

            while (!baseProviderFailed & decoratorSucceeded)
            {
                try
                {
                    provider.GetWeather(city);
                    baseProviderFailed = false;
                }
                catch
                {
                    baseProviderFailed = true;
                }

                try
                {
                    decorated.GetWeather(city);
                    decoratorSucceeded = true;
                }
                catch
                {
                    decoratorSucceeded = false;
                }
            }

            Console.WriteLine("\nNot decorated provider failed.");
            Console.WriteLine("Decorated provider failed too!");

            Console.ReadLine();
        }
    }
}
