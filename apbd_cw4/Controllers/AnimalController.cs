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
    [Route("api/animals")]
    [ApiExplorerSettings(GroupName = "animals")]
    public class AnimalController : ControllerBase
    {
        private static List<Animal> _animals = new()
        {
            new Animal{ Id = 1, Name = "a1", Category = "cat",  Mass = 5.2, Colour  = "white"},
            new Animal{ Id = 2, Name = "a2", Category = "cat",  Mass = 5.2, Colour  = "black"},
            new Animal{ Id = 3, Name = "a3", Category = "dog",  Mass = 5.2, Colour  = "white"},
            new Animal{ Id = 4, Name = "a4", Category = "dog",  Mass = 5.2, Colour  = "black"},
        };

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animals);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if( animal == null)
            {
                return NotFound($"Animal with id {id} was not found");
            }
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult PostAnimal(Animal animal)
        {
            var animalInBase = _animals.FirstOrDefault(a => a.Id == animal.Id);
            if (animalInBase != null)
            {
                return Conflict($"Animal with id {animal.Id} already exists");
            }
            _animals.Add(animal);
            return Created("", animal);
        }

        [HttpPut]
        public IActionResult UpdateAnimal(Animal animal)
        {
            var animalInBase = _animals.FirstOrDefault(a => a.Id == animal.Id);
            if (animalInBase == null)
            {
                return NotFound($"Animal with id {animal.Id} was not found");
            }
            _animals.Remove(animalInBase);
            _animals.Add(animal);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalInBase = _animals.FirstOrDefault(a => a.Id == id);
            if (animalInBase == null)
            {
                return NotFound($"Animal with id {id} was not found");
            }
            _animals.Remove(animalInBase);
            return Ok();
        }
    }
}

