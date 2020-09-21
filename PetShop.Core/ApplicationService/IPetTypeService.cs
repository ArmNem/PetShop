using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
 public interface IPetTypeService
    {
        Pettype NewType(string name);
        Pettype CreateType(Pettype type);
        List<Pettype> GetAllTypes();
        Pettype UpdateType(Pettype type);
        Pettype FindTypeById(int id);
        void DeleteType(int id);
    }
}
