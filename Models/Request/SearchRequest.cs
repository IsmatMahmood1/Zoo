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
        public int PageSize { get; set; } = 10;
        public Species? Species { get; set; }       
        public Classification? Classification { get; set; }
        public int Age { get; set; } = 0;
        public string Name { get; set; } = null;
        public DateTime DateAcquired { get; set; } = default(DateTime);
        public SortOrderBy SortOrderBy { get; set; } = 0;



    }
}