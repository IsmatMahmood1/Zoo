using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Models.Response
{
    public class AnimalResponse
    {
        private readonly AnimalDbModel _animal;

        public AnimalResponse(AnimalDbModel animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;

        public Sex Sex => _animal.Sex;
        public int Age => GetAge(_animal.DateOfBirth);

        public DateTime DateOfBirth => _animal.DateOfBirth;

        public DateTime DateAcquired => _animal.DateAcquired;

        public Classification Classification => _animal.Classification;

        public Species Species => _animal.Species;

        private int GetAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}