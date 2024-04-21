using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cw4_s24798.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cw4_s24798.Controllers
{
    [ApiController]
    [Route("api/visits")]
    [ApiExplorerSettings(GroupName = "visits")]
    public class VisitController : ControllerBase
    {
        private static List<Visit> _visits = new()
        {
            new Visit {Date = DateOnly.Parse("2024-04-21"), Description = "aaa", Id = 1, Price = 122.5},
            new Visit {Date = DateOnly.Parse("2024-03-21"), Description = "bbb", Id = 1, Price = 122.5},
            new Visit {Date = DateOnly.Parse("2024-02-21"), Description = "ccc", Id = 2, Price = 122.5}
        };
        // GET: /<controller>/
        [HttpGet("{id:int}")]
        public IActionResult GetVisits(int id)
        {
            var visits = _visits.Where(v => v.Id == id).ToList();
            if (visits.Count == 0)
            {
                return NotFound($"Visits for animal with id {id} was not found");
            }
            return Ok(visits);
        }

        [HttpPost]
        public IActionResult GetVisits(Visit visit)
        {
            _visits.Add(visit);
            return Created("",visit);
        }
    }
}
