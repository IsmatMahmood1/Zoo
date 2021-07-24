using System.Linq;

namespace Zoo.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }
        public Animal GetById(int id)
        {
            return _context.Animals
                .Single(animal => animal.Id == id);
        }
        public Animal Create(CreateAnimalRequest newAnimal)
        {

            var insertResponse = _context.Animals.Add(new Animal
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