using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Zoo.Repositories;
using Zoo.Models.Response;
using Zoo.Models.Request;

namespace Zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        [HttpGet("search")]
        public List<AnimalResponse> Search([FromQuery] SearchRequest searchRequest)
        {

            var animals = _animals.Search(searchRequest);

            return animals;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetByAnimalId([FromRoute] int id)
        {
            var animal = _animals.GetAnimalById(id);

            return new AnimalResponse(animal);
        }
        
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = _animals.CreateAnimalInDb(newAnimal);

            var url = Url.Action("GetAnimalById", new { id = animal.Id });
            var responseViewModel = new AnimalResponse(animal);
            return Created(url, responseViewModel);
        }

    }

}
