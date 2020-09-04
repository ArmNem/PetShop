using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> GetOwners();
        public Owner AddOwner(Owner owner);
        public Owner FindOwnerById(int id);
        public void DeleteOwner(int id);
        public Owner UpdateOwner(Owner updateOwner);
    }
}
