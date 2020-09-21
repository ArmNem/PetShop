using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace Infrastructure.Data
{
    public class PetShopRepository: IPetShopRepository
    {
        private static int _id = 1;
        private static List<Pet> pets = new List<Pet>();

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

        
        public Pet DeletePet(int id)
        {
            var petfound = FindPetById(id);
            if (petfound == null)
            {
                return null;
            }
            pets.Remove(petfound);
            return petfound;
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
                petFromDB.Owner = updatepet.Owner;
                petFromDB.Price = updatepet.Price;
                return petFromDB;
            }

            return null;
        }

        public Pet FindPetById(int id)
        {
            /*return pets.Select(c => new Pet()
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Type = c.Type,
                     BirthDate = c.BirthDate,
                     SoldDate = c.SoldDate,
                     Color = c.Color,
                     Owner = c.Owner,
                     Price = c.Price
                 }
             ).FirstOrDefault(c => c.Id == id);*/
            foreach (var owner in pets)
            {
                if (owner.Id == id)
                    return owner;
            }
            return null;
        }
        public FilteredList<Pet> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Pet>();

            filteredList.TotalCount = pets.Count;
            filteredList.FilterUsed = filter;

            IEnumerable<Pet> filtering = pets;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "Name":
                        filtering = filtering.Where(c => c.Name.Contains(filter.SearchText));
                        break;
                    case "Color":
                        filtering = filtering.Where(c => c.Color.Contains(filter.SearchText));
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Pet).GetProperty(filter.OrderProperty);
                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(c => prop.GetValue(c, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }

            filteredList.List = filtering.ToList();
            return filteredList;
        }
        public List<Pet> Filter(string orderDir)
        {
            if ("asc".Equals(orderDir))
            {
                return pets
                    .OrderBy(c => c.Name)
                    .ToList();
            }
            return pets
                .OrderByDescending(c => c.Name)
                .ToList();
        }
    }
}
