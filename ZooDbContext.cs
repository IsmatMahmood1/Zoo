using Microsoft.EntityFrameworkCore;
using System;
using Zoo.Models.DbModels;

namespace Zoo
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }

        public DbSet<AnimalDbModel> Animals { get; set; }
        public DbSet<EnclosureDbModel> Enclosures { get; set; }
        public DbSet<ZookeeperDbModel> ZooKeepers { get; set; }

    }
}
