using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models.Enums;

namespace Zoo
{
    public class CreateAnimalRequest
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public Sex Sex { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateAcquired { get; set; }
        [Required]
        public Classification Classification { get; set; }
        [Required]
        public Species Species { get; set; }

    }
}