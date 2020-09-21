using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public interface IPetShopService
   {
       public Pet NewPet(string name, Pettype type, DateTime birthDate,DateTime soldDate, string color, List<Owner> Owner, double price);
        Pet CreatePet(Pet pet);
        List<Pet> GetAllPets();
        public Pet UpdatePet(Pet petUpdate);
        public Pet FindPetById(int id);
        public Pet FindPetByIdWithOwner(int id);
        public Pet DeletePet(int id);
        public List<Pet> GetAllByType(Pettype type);
        public List<Pet> GetCheapestPets();

        public List<Pet> SortPetsByPrice();

        FilteredList<Pet> GetAllFilterPets(Filter filter);
    }
}
