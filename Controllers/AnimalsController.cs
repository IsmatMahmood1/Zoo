using Microsoft.AspNetCore.Mvc;
using Zoo.Repositories;

namespace Zoo.Controllers
{
    [ApiController]
    [Route("/")]

    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        private AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

    }

}
