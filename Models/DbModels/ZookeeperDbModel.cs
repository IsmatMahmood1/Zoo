using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class ZookeeperDbModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public EnclosureDbModel Enclosure { get; set; }
        public List<AnimalDbModel> Animals { get; set; }

    }
}