using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public class OwnerService: IOwnerService
   {
       private readonly IOwnerRepository _ownerRepository;
       private IPetShopRepository _petshoprepository;


       public OwnerService(IOwnerRepository ownerRepository,IPetShopRepository petShopRepository)
       {
           _ownerRepository = ownerRepository;
           _petshoprepository = petShopRepository;
       }
        public Owner NewOwner(string name)
        {
            var newowner = new Owner()
            {
                Name = name
            };
            return newowner;
        }

        public Owner CreateOwner(Owner owner)
        {
            if (owner.OwnedPet == null || owner.OwnedPet.Id <= 0)
            {
                throw new InvalidDataException("To create an Owner you need a Pet");
            }

            if (_petshoprepository.FindPetById(owner.OwnedPet.Id)==null)
            {
                throw new InvalidDataException("Pet not found");
            }

            if (owner.Name == null)
            {
                throw new InvalidDataException("Owner needs a name");
            }
           return _ownerRepository.AddOwner(owner);
        }

        public List<Owner> GetAllOwners()
        {
                
            return _ownerRepository.GetOwners().ToList();
        }

        public Owner UpdateOwner(Owner updateowner)
        {
            
            var owner = FindOwnerById(updateowner.Id);
            if (owner.Id != updateowner.Id || updateowner.Id < 1)
            {
                throw  new InvalidDataException("Parameter Id and Owner Id must be the same");
            }
            if (updateowner.Name == null)
            {
                throw new InvalidDataException("Owner must have a name");
            }
            owner.Name = updateowner.Name;
            return owner;
        }

        public Owner FindOwnerById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Owner not found");
            }
            return _ownerRepository.FindOwnerById(id);
        }

        public void DeleteOwner(int id)
        {
            if (id <= 0 )
            {
                throw new InvalidDataException("Owner not found");
            }
            _ownerRepository.DeleteOwner(id);
        }
    }
}
