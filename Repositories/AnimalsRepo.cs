namespace Zoo.Repositories
{
    public interface IAnimalsRepo
    {

    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }

    }
}