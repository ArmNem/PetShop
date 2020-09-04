using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public class OwnerService: IOwnerService
   {
       private readonly IOwnerRepository _ownerRepository;

       public OwnerService(IOwnerRepository ownerRepository)
       {
           _ownerRepository = ownerRepository;
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
           return _ownerRepository.AddOwner(owner);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetOwners().ToList();
        }

        public Owner UpdateOwner(Owner updateowner)
        {
            var owner = FindOwnerById(updateowner.Id);
            owner.Name = updateowner.Name;
            return owner;
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.FindOwnerById(id);
        }

        public void DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }
    }
}
