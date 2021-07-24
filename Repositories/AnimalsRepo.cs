using System;
using System.Collections.Generic;
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
        List<AnimalResponse> Search(SearchRequest search);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }

        public List<AnimalResponse> Search(SearchRequest search)
        {
            var mostRecentBirthday = DateTime.Today.AddYears(-search.Age);
            var earliestBirthday = mostRecentBirthday.AddYears(-1);

            var unorderedSearch =  _context.Animals
                .Where(a => search.Species == null || a.Species == search.Species)
                .Where(a => search.Classification == null || a.Classification == search.Classification)
                .Where(a => search.Age == 0 || a.DateOfBirth > earliestBirthday && a.DateOfBirth <= mostRecentBirthday)
                .Where(a => search.Name == "" || a.Name == search.Name)
                .Where(a => search.DateAcquired == default(DateTime) || a.DateAcquired == search.DateAcquired);
            return OrderResponse(unorderedSearch, search)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize)
                .Select(a => new AnimalResponse(a))
                .ToList();

        }
        public IEnumerable<AnimalDbModel> OrderResponse(IEnumerable<AnimalDbModel> response, SearchRequest search)
        {
            switch (search.SortOrderBy)
            {
                case (Models.Enums.SortOrderBy)0:
                    response = response.OrderBy(a => a.Species);
                    break;
                case (Models.Enums.SortOrderBy)1:
                    response = response.OrderBy(a => a.Classification);
                    break;
                case (Models.Enums.SortOrderBy)2:
                    response = response.OrderBy(a => a.DateOfBirth);
                    break;
                case (Models.Enums.SortOrderBy)3:
                    response = response.OrderBy(a => a.Name);
                    break;
                case (Models.Enums.SortOrderBy)4:
                    response = response.OrderBy(a => a.DateAcquired);
                    break;

                default:
                    response = response.OrderBy(a => a.Species);
                    break;
            }
            return response;
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