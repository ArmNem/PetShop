using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
   public interface IPetShopRepository
   {
       public IEnumerable<Pet> GetPets();
       public Pet AddPet(Pet pet);
       public Pet FindPetById(int id);
       public Pet DeletePet(int id);
       public Pet UpdatePet(Pet updatepet);
       List<Pet> Filter(string orderDir);
       FilteredList<Pet> ReadAll(Filter filter);
    }
}
