using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class EnclosureDbModel
    {
        public int Id { get; set; }

        public Enclosure Enclosure { get; set; }
        public int Capacity { get; set; }
        public List<ZookeeperDbModel> Zookeepers { get; set; }
        public List<AnimalDbModel> Animals { get; set; }


    }
}