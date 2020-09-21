using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PetShop.Core.Entity
{
   public class Pettype
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public List<Pet> PetsInType { get; set; }
    }
}
