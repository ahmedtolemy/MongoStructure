using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDomain;
using MongoPresistence;
using MongoRepository.Contract;
using MongoRepository.Implementation;

namespace MongoStructure.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller

    {
      //  private readonly IApplicationRepository _apprepo;

        public SampleDataController()
        {
          //  _apprepo = apprepo;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var app1 = new Application() { Name = "app" , CreatedOn = DateTime.Now ,ModulesIds=new List<string>(),ExtraElement=new BsonDocument()};
            //  for (int i = 0; i < 1000000; i++)
            //{
            //  app1.ModulesIds.Add("he");
            // }88
            app1.ExtraElement.Add("age", 18);
            app1.ExtraElement.Add("address", "street");
            new ApplicationRepository(new MongoContext()).InsertOne(app1);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;


            var app= new ApplicationRepository(new MongoContext()).All();
            
            var rng = new Random();
            return app.Select(index => new WeatherForecast
            {
                DateFormatted = index.Name,
                TemperatureC = rng.Next(-20, 55),
                Summary = index.Id.ToString()
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
