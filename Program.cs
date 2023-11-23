using ConsoleApp3;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
  
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");



        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("https://localhost:7028/");


            var responseTask = httpClient.GetAsync("WeatherForecast");
            responseTask.Wait();

            var result = responseTask.Result;
            Console.WriteLine(result.IsSuccessStatusCode);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                var weather = readTask.Result;
                

                var weatherForcasts = JsonConvert.DeserializeObject<List<WeatherForcast>>(weather);

                Console.WriteLine(weatherForcasts[0].Date);

                foreach (var item in weatherForcasts)
                {
                   
                    Console.Write(item.Date + " ");
                    Console.Write(item.TemperatureC + " ");
                    Console.WriteLine(item.Summary + " ");

                }
            }
        }       
    }
} 