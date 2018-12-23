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
            var xx = Builders<Application>.Filter.Eq("Name", "app2");
           // var sort =Builders<Application>.Sort();
          //  SortDefinition<Application> sprt = new BsonDocument("Name", 1);
           // xx = xx & Builders<Application>.Filter.Eq("Name", "app2");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var app= new ApplicationRepository(new MongoContext()).All();
           // var obj = ObjectId.Parse("5c1bcacb07a410084076e028");
      var c=      new ApplicationRepository(new MongoContext()).GetOne(s => s.Id ==ObjectId.Parse("5c1c05b0298d309cb4d09416"));
           var value= c.Id.ToString();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            new ApplicationRepository(new MongoContext()).InsertOne(new Application() { Name = "app1", CreatedOn = DateTime.Now });
            var xs=app.FirstOrDefault().Id.ToString();
            
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
