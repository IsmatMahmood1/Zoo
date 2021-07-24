using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models.Enums;

namespace Zoo.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;

        public Sex Sex => _animal.Sex;

        public DateTime DateOfBirth => _animal.DateOfBirth;

        public DateTime DateAcquired => _animal.DateAcquired;

        public Classification Classification => _animal.Classification;

        public Species Species => _animal.Species;

    }
}