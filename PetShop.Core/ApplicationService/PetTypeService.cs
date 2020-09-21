using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
   public class PetTypeService : IPetTypeService
   {
       private IPetTypeRepository _petTypeRepo;

       public PetTypeService(IPetTypeRepository petTypeRepository)
       {
           _petTypeRepo = petTypeRepository;
       }
       public Pettype NewType(string name)
       {
           var newtype = new Pettype()
           {
               TypeName = name
           };
           return newtype;
        }

       public Pettype CreateType(Pettype type)
       {
           if (_petTypeRepo.FindPetTypeById(type.Id) == null)
           {
               throw new InvalidDataException("Type not found");
           }

           if (type.TypeName == null)
           {
               throw new InvalidDataException("Type needs a name");
           }
           return _petTypeRepo.AddType(type);
        }

       public List<Pettype> GetAllTypes()
       {
           return _petTypeRepo.GetTypes().ToList();
        }

       public Pettype UpdateType(Pettype updatetype)
       {
           var type = FindTypeById(updatetype.Id);
           if (type.Id != updatetype.Id || updatetype.Id < 1)
           {
               throw new InvalidDataException("Parameter Id and Type Id must be the same");
           }
           if (updatetype.TypeName == null)
           {
               throw new InvalidDataException("Type must have a name");
           }
           type.TypeName = updatetype.TypeName;
           return type;
        }

       public Pettype FindTypeById(int id)
       {
           if (id <= 0)
           {
               throw new InvalidDataException("Type not found");
           }
           return _petTypeRepo.FindPetTypeById(id);
        }

       public void DeleteType(int id)
       {
           if (id <= 0)
           {
               throw new InvalidDataException("Type not found");
           }
           _petTypeRepo.DeleteType(id);
        }
   }
}
