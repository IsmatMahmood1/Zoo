using Microsoft.EntityFrameworkCore;
using System;

namespace Zoo
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

    }
}
