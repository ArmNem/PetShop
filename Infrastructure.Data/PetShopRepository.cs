using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace Infrastructure.Data
{
    public class PetShopRepository: IPetShopRepository
    {
        private static int _id = 1;
        private static List<Pet> pets = new List<Pet>();

        public void InitData()
        {
            pets.Add(new Pet()
                {
                    Id = _id++,
                    Name = "Rex",
                    Type = "Dog",
                    BirthDate = DateTime.Now.AddYears(-3),
                    SoldDate = DateTime.Now.AddYears(-2),
                    Color = "Black",
                    PrevOwner = "Johhny",
                    Price = 3000
                }
            );
            pets.Add(new Pet()
                {
                    Id = _id++,
                    Name = "Mobo",
                    Type = "Chipmunk",
                    BirthDate = DateTime.Now.AddYears(-1),
                    SoldDate = DateTime.Now.AddMonths(-4),
                    Color = "Light Brown",
                    PrevOwner = "Chuck",
                    Price = 1500
                }
            );
            pets.Add(new Pet()
                {
                    Id = _id++,
                    Name = "Luka",
                    Type = "Cat",
                    BirthDate = DateTime.Now.AddYears(-2),
                    SoldDate = DateTime.Now.AddYears(-1),
                    Color = "Grey",
                    PrevOwner = "Ben",
                    Price = 2000
                }
            );
        }

        public IEnumerable<Pet> GetPets()
        {
            return pets;
        }

        public Pet AddPet(Pet pet)
        {
            pet.Id = _id++;
            pets.Add(pet);
            return pet;
        }

        
        public void DeletePet(int id)
        {
            var petfound = FindPetById(id);
            if (petfound != null)
            {
                 pets.Remove(petfound);
            }

            
        }

        public Pet UpdatePet(Pet updatepet)
        {
            var petFromDB = this.FindPetById(updatepet.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = updatepet.Name;
                petFromDB.Type = updatepet.Type;
                petFromDB.BirthDate = updatepet.BirthDate;
                petFromDB.SoldDate = updatepet.SoldDate;
                petFromDB.Color = updatepet.Color;
                petFromDB.PrevOwner = updatepet.PrevOwner;
                petFromDB.Price = updatepet.Price;
                return petFromDB;
            }

            return null;
        }

        public Pet FindPetById(int id)
        {
            foreach (var pet in pets)
            {
                if (pet.Id == id)
                    return pet;
            }
            return null;
        }
    }
}
