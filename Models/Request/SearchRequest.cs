using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models;

namespace Zoo.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string Filters => Search == null ? "" : $"&search={Search}";

        private string _search;

        public string Search
        {
            get => _search?.ToLower();
            set => _search = value;
        }
    }
}