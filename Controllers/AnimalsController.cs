using Microsoft.AspNetCore.Mvc;
using Zoo.Repositories;
using Zoo.Models.Response;

namespace Zoo.Controllers
{
    [ApiController]
    [Route("/")]

    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetById(id);

            return new AnimalResponse(animal);
        }
    }

}
