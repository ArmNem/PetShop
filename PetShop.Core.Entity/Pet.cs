using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace PetShop.Core.Entity
{
   public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Pettype Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public List<Owner> Owner { get; set; }
        public double Price { get; set; }
    }
}
