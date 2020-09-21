using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace Infrastructure.Data
{
  public class PetTypeRepository : IPetTypeRepository
    {
        private static int _id = 1;
        private static List<Pettype> types = new List<Pettype>();

        public IEnumerable<Pettype> GetTypes()
        {
            return types;
        }

        public Pettype AddType(Pettype type)
        {
            type.Id = _id++;
            types.Add(type);
            return type;
        }

        public Pettype FindPetTypeById(int id)
        {
            foreach (var type in types)
            {
                if (type.Id == id)
                    return type;
            }
            return null;
        }

        public Pettype DeleteType(int id)
        {
            var typefound = FindPetTypeById(id);
            if (typefound != null)
            {
                types.Remove(typefound);
            }

            return typefound;
        }

        public Pettype UpdateType(Pettype updatetype)
        {
            var typefromDB = this.FindPetTypeById(updatetype.Id);
            if (typefromDB != null)
            {
                typefromDB.TypeName = updatetype.TypeName;
                return typefromDB;
            }

            return null;
        }
    }
}
