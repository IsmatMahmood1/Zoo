using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.SampleData
{
    public static class SampleEnclosures
    {
        public static int NumberOfEnclosures = 5;

        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "0", "10" },
            new List<string> { "1", "50" },
            new List<string> { "2", "40" },
            new List<string> { "3", "6" },
            new List<string> { "4", "10" },
        };

        public static IEnumerable<EnclosureDbModel> GetEnclosures()
        {
            return Enumerable.Range(0, NumberOfEnclosures).Select(CreateRandomEnclosure);
        }
        private static EnclosureDbModel CreateRandomEnclosure(int index)
        {
            return new EnclosureDbModel
            {
                Enclosure = (Enclosure)int.Parse(_data[index][0]),
                Capacity = int.Parse(_data[index][1]),
            };
        }

    }
}
