using Microsoft.EntityFrameworkCore;
using System;
using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class AnimalDbModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAcquired { get; set; }

        public Classification Classification { get; set; }
        public Species Species { get; set; }

        public EnclosureDbModel Enclosure { get; set; }
        public ZookeeperDbModel Zookeeper { get; set; }

    }
}