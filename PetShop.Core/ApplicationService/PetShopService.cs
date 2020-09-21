using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public class PetShopService: IPetShopService
    {
        readonly IPetShopRepository _petShopRepo;
        private readonly IOwnerRepository _ownerRepo;

        public PetShopService(IPetShopRepository petShopRepository,IOwnerRepository ownerRepository )
        {
            _petShopRepo = petShopRepository;
            _ownerRepo = ownerRepository;
        }
        public Pet NewPet(string name, Pettype type, DateTime birthDate, DateTime soldDate, string color, List<Owner> Owner,
            double price)
        {
            var newpet = new Pet()
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                Owner = Owner,
                Price = price
            };
            return newpet;
        }
        public Pet CreatePet(Pet pet)
        {
            if (pet.Name == null)
            {
                throw new InvalidDataException("Pet must have a name");
            }
            return _petShopRepo.AddPet(pet);
        }
        public Pet FindPetById(int id)
        {
            return _petShopRepo.FindPetById(id);
        }

        public Pet FindPetByIdWithOwner(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Pet not found");
            }
            var pet = _petShopRepo.FindPetById(id);
            pet.Owner = _ownerRepo.GetOwners().Where(
                owner => owner.OwnedPet.Id == pet.Id).ToList();
            return pet;
        }

        public List<Pet> GetAllPets()
        {
            return _petShopRepo.GetPets().ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {

            var pet = FindPetById(petUpdate.Id);
            if (pet.Id != petUpdate.Id)
            {
                throw new InvalidDataException("Parameter ID and Pet ID must be the same");
            }

            if (petUpdate.Name == null)
            {
                throw new InvalidDataException("Pet must have a name");
            }
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.BirthDate = petUpdate.BirthDate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.Owner = petUpdate.Owner;
            pet.Price = petUpdate.Price;
            return pet;
        }
        public Pet DeletePet(int id)
        {
            if (id < 1)
            {
                throw new InvalidDataException("Pet not found");
            }
            return _petShopRepo.DeletePet(id);
        }

        public List<Pet> GetAllByType(Pettype type)
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
        public FilteredList<Pet> GetAllFilterPets(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "Name";
            }
            return _petShopRepo.ReadAll(filter);
        }
    }
}
