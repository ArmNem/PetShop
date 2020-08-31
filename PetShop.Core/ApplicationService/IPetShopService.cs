using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public interface IPetShopService
   {
       public Pet NewPet(string name, string type, DateTime birthDate,DateTime soldDate, string color, string prevOwner, double price);
        Pet CreatePet(Pet pet);
        List<Pet> GetAllPets();
        public Pet UpdatePet(Pet petUpdate);
        public Pet FindPetById(int id);
        public void DeletePet(int id);
        public List<Pet> GetAllByType(string type);
        public List<Pet> GetCheapestPets();

        public List<Pet> SortPetsByPrice();
   }
}
