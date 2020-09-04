using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace Infrastructure.Data
{
  public class OwnerRepository: IOwnerRepository
    {
        private static int _id = 1;
        private static List<Owner> owners = new List<Owner>();


        public IEnumerable<Owner> GetOwners()
        {
            return owners;
        }
        public Owner AddOwner(Owner owner)
        {
            owner.Id = _id++;
            owners.Add(owner);
            return owner;
        }
        public Owner FindOwnerById(int id)
        {
            foreach (var owner in owners)
            {
                if (owner.Id == id)
                    return owner;
            }
            return null;
        }
        public void DeleteOwner(int id)
        {
            var ownerfound = FindOwnerById(id);
            if (ownerfound != null)
            {
                owners.Remove(ownerfound);
            }
        }
        public Owner UpdateOwner(Owner updateOwner)
        {
            var ownerFromDB = this.FindOwnerById(updateOwner.Id);
            if (ownerFromDB != null)
            {
                ownerFromDB.Name = updateOwner.Name;
                return ownerFromDB;
            }

            return null;
        }
    }
}
