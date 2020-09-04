using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public interface IOwnerService
   {
       Owner NewOwner(string name);
       Owner CreateOwner(Owner owner);
       List<Owner> GetAllOwners();
       Owner UpdateOwner(Owner owner);
       Owner FindOwnerById(int id);
       void DeleteOwner(int id);
   }
}
