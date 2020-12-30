using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyAPICore.Controllers
{
    [Route("api/[controller]")]
    public class WeatherForecastController : MainController
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

        [HttpGet]
        // Não consegue retornar código de BadRequest e Ok, por isto é desvantajoso retornar o tipo
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpGet("{id:int}")]
        // Aqui como é tipado o retorno não precisa do Ok(data)
        public ActionResult<string> GetPorId([FromRoute]int id)
        {
            return "xD";
        }

        [HttpGet("getAllById/{id:int}")]
        // Aqui como não é tipado o retorno deve ter o Ok(data)
        // Não precisa do FromRoute, pois é implícito
        public ActionResult GetTodosPorId(int id)
        {
            var valores = new string[] { "xD", "HAHA", "My mother arrived" };

            if (valores.Length <= 0)
            {
                return CustomResponse();
            }

            return CustomResponse(valores);
        }

        [HttpPost]
        public void Post([FromBody] string value) 
        {
        }
        
         //   [HttpPost]
         //   [ProducesResponseType(typeof(Product), StatusCode.Status201Created)]
	     //  [ProducesResponseType(typeof(Product), StatusCode.Status400BadRequest)]
         //   public void Post([FromBody] string value) 
         //   {
         //       var valores = new string[] { "xD", "HAHA", "My mother arrived" };

         //       return CreatedAtAction(nameof(Post), valores);
         //   }
        
    }
}
