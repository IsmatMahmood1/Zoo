using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Request;
using Zoo.Models.Response;

namespace Zoo.Repositories
{
    public interface IAnimalsRepo
    {
        AnimalDbModel GetAnimalById(int id);
        AnimalDbModel CreateAnimalInDb(CreateAnimalRequest newAnimal);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }
        public AnimalDbModel GetAnimalById(int id)
        {
            return _context.Animals
                .Single(animal => animal.Id == id);
        }
        public AnimalDbModel CreateAnimalInDb(CreateAnimalRequest newAnimal)
        {

            var insertResponse = _context.Animals.Add(new AnimalDbModel
            {
                Name = newAnimal.Name,
                Sex = newAnimal.Sex,
                DateOfBirth = newAnimal.DateOfBirth,
                DateAcquired = newAnimal.DateAcquired,
                Classification = newAnimal.Classification,
                Species = newAnimal.Species,

            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }

    }
}