using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace meoapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WappController : ControllerBase
    {
        private static readonly string[] something = new[]
        {
            "city", "state", "cold", "winter", "nasha", "story", "my"
        };

        private readonly ILogger<WappController> _logger;

        public WappController(ILogger<WappController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<appModel> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new appModel
            {
                Date = DateTime.Now.AddDays(index),
                Summary = something[rng.Next(something.Length)]
            })
            .ToArray();
        }
    }
}
