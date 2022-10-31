﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetApiTest.ControllerTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PetController : ControllerBase
    {
        static private List<Pet> pets = new List<Pet>();
        [HttpPost("addNewPet")]
        public Pet AddNewPet(Pet pet)
        {
            pets.Add(pet);
            return pet;
        }

        [HttpGet("getAllPets")]
        public List<Pet> GetAllPets()
        {
            return pets;
        }
        
        [HttpGet("findPetByName")]
        public Pet FindPetByName([FromQuery] string name)
        {
            return pets.Find(pet => pet.Name == name);
        }

        [HttpPut("changePetPrice")]
        public Pet ChangePetPrice(Pet pet)
        {
            var oldPricePet = pets.Find(p => p.Name == pet.Name);
            pets.Remove(oldPricePet);
            pets.Add(pet);
            return pet;
        }

        [HttpDelete("releaseAllPets")]
        public void ReleaseAllPets()
        {
            pets.Clear();
        }
    }
}
