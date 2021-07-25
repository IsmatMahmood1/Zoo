using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models;
using Zoo.Models.Enums;

namespace Zoo.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public Species? Species { get; set; } = null;
        public Classification? Classification { get; set; } = null;
        public int Age { get; set; }
        public string Name { get; set; } = null;
        public DateTime DateAcquired { get; set; } = default(DateTime);
        public SortOrderBy SortOrderBy { get; set; } = 0;

    }
}