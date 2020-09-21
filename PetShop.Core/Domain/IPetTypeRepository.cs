using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
   public interface IPetTypeRepository
    {
        public IEnumerable<Pettype> GetTypes();
        public Pettype AddType(Pettype pet);
        public Pettype FindPetTypeById(int id);
        public Pettype DeleteType(int id);
        public Pettype UpdateType(Pettype updatetype);
    }
}
