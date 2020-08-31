using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public class PetShopService: IPetShopService
    {
        readonly IPetShopRepository _petShopRepo;

        public PetShopService(IPetShopRepository petShopRepository )
        {
            _petShopRepo = petShopRepository;
        }
        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string prevOwner,
            double price)
        {
            var newpet = new Pet()
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PrevOwner = prevOwner,
                Price = price
            };
            return newpet;
        }
        public Pet CreatePet(Pet pet)
        {
            return _petShopRepo.AddPet(pet);
        }
        public Pet FindPetById(int id)
        {
            return _petShopRepo.FindPetById(id);
        }
        public List<Pet> GetAllPets()
        {
            return _petShopRepo.GetPets().ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.BirthDate = petUpdate.BirthDate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.PrevOwner = petUpdate.PrevOwner;
            pet.Price = petUpdate.Price;
            return pet;
        }
        public void DeletePet(int id)
        {
           _petShopRepo.DeletePet(id);
        }

        public List<Pet> GetAllByType(string type)
        {
            var list = _petShopRepo.GetPets();
            var query = list.Where(pet => pet.Type.Equals(type));
            return query.ToList();
        }

        public List<Pet> GetCheapestPets()
        {
            var list = _petShopRepo.GetPets();
            var query = list.OrderBy(pet => pet.Price).Take(1);
            return query.ToList();
        }

        public List<Pet> SortPetsByPrice()
        {
            var list = _petShopRepo.GetPets();
            var query = list.OrderBy(pet => pet.Price);
            return query.ToList();
        }
    }
}
