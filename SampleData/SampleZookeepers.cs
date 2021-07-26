using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.SampleData
{
    public static class SampleZookeepers
    {
        public static int NumberOfZookeepers = 10;

        private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Oscar Wild", "0" },
            new List<string> { "Earnest Hemmingway", "0" },
            new List<string> { "David Livingstone","1" },
            new List<string> { "Elizabeth Windsor", "1" },
            new List<string> { "Anne Hathaway", "2" },
            new List<string> { "Liz Goswell", "2"},
            new List<string> { "Jane Goodall", "3"},
            new List<string> { "David Attenborough", "3"},
            new List<string> { "Amelia Earhart", "4"},
            new List<string> { "Francis Crick", "4" }
        };

        public static IEnumerable<ZookeeperDbModel> GetZookeepers()
        {
            var enclosures = SampleEnclosures.GetEnclosures().ToList();

            return Enumerable.Range(0, NumberOfZookeepers)
                .Select(i => CreateRandomZookeeper(i, enclosures));
        }
        private static ZookeeperDbModel CreateRandomZookeeper(int index, IList<EnclosureDbModel> enclosures)
        {
            return new ZookeeperDbModel
            {
                Name = _data[index][0],
                Enclosure = enclosures[int.Parse(_data[index][1])],

            };
        }

        public static List<ZookeeperDbModel> UpdateZookeepers(
    List<ZookeeperDbModel> zookeepers, List<EnclosureDbModel> enclosures)
        {
            var random = new Random().Next(0,5);
            zookeepers.Select(z => z.Enclosure = (EnclosureDbModel)enclosures.Select(e => e.Id == random));
            //Enclosure = enclosures.Select(e => e.Enclosure == (Enclosure)Int32.Parse(_data[index][0])),
            //foreach (var zookeeper in zookeepers)
            //{
            //    zookeeper.Enclosures = animals
            //        .Where(a => a.Zookeeper.Name == zookeeper.Name)
            //        .Select(a => a.Enclosure)
            //        .Distinct()
            //        .ToList();
            //}
            return zookeepers;
        }

    }
}
