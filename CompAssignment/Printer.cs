using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;
using PetShop.Core.ApplicationService;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.UI
{
    public class Printer
    {

        /* private IPetShopService _petService;
 
 
         private string[] menuitems =
         {
             "List all pets",
             "Search pets by type",
             "Create a new pet",
             "Delete a pet",
             "Update a pet",
             "Sort pets by price",
             "Show cheapest pet",
             "Exit"
         };
 
         public Printer(IPetShopService petshopService)
         {
             _petService = petshopService;
 
             var selection = ShowMenu();
             while (selection != 8)
             {
                 switch (selection)
                 {
                     case 1:
                         PrintAllPets();
                         break;
                     case 2:
                         PrintPetsBYSearchType();
                         break;
                     case 3:
                         var name = AskQuestion("Name: ");
                         var type = AskQuestion("Type: ");
                         DateTime bdate = DateTime.Parse(AskQuestion("Birth: "));
                         DateTime sdate = DateTime.Parse(AskQuestion("Sold date: "));
                         var color = AskQuestion("Color: ");
                         var prev = AskQuestion("Previous owner: ");
                         double price = Double.Parse(AskQuestion("Price: "));
                         var pet = _petService.NewPet(name, type, bdate, sdate, color, prev, price);
                         _petService.CreatePet(pet);
                         break;
                     case 4:
                         var id = PrintFindPetId();
                         _petService.DeletePet(id);
                         break;
                     case 5:
                         var forUpdate = PrintFindPetId();
                         var petToUPdate = _petService.FindPetById(forUpdate);
                         Console.WriteLine("Updating" + petToUPdate.Name);
                         var newname = AskQuestion("Name: ");
                         var newtype = AskQuestion("Type: ");
                         DateTime newbdate = DateTime.Parse(AskQuestion("Birth: "));
                         DateTime newsdate = DateTime.Parse(AskQuestion("Sold date: "));
                         var newcolor = AskQuestion("Color: ");
                         var newprev = AskQuestion("Previous owner: ");
                         double newprice = Double.Parse(AskQuestion("Price: "));
                         UpdatePet(forUpdate, newname, newtype, newbdate, newsdate, newcolor, newprev, newprice);
                         break;
                     case 6:
                         PrintSortPetsBíPrice();
                         break;
                     case 7:
                         PrintCheapestPet();
                         break;
 
                 }
 
                 selection = ShowMenu();
             }
 
             Console.WriteLine("Bye!");
             Console.ReadLine();
         }
 
         public int ShowMenu()
         {
             Console.WriteLine("Press a number to start\n");
             for (int i = 0; i < menuitems.Length; i++)
             {
                 Console.WriteLine(i + 1 + "." + menuitems[i]);
             }
 
             int selection;
             while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 8)
             {
                 Console.WriteLine("Please type a number between 1 - 8");
             }
 
             return selection;
         }
 
         public void PrintAllPets()
         {
             List<Pet> listOfPets = _petService.GetAllPets();
             Console.WriteLine("Printing all pets:\n");
             foreach (var pet in listOfPets)
             {
                 Console.WriteLine(
                     $"Id: {pet.Id} || Name: {pet.Name} || Type: {pet.Type} || BirthDate: {pet.BirthDate} || SoldDate: {pet.SoldDate} || Color: {pet.Color} || PreviousOwner: {pet.PrevOwner} || Price: {pet.Price}");
             }
         }
 
         public void PrintPetsBYSearchType()
         {
             var search = AskQuestion("Type: ");
             List<Pet> list = _petService.GetAllByType(search);
             foreach (var pet in list)
             {
                 Console.WriteLine(
                     $"Id: {pet.Id} || Name: {pet.Name} || Type: {pet.Type} || BirthDate: {pet.BirthDate} || SoldDate: {pet.SoldDate} || Color: {pet.Color} || PreviousOwner: {pet.PrevOwner} || Price: {pet.Price}");
             }
 
         }
 
         public void PrintCheapestPet()
         {
             List<Pet> list = _petService.GetCheapestPets();
             foreach (var pet in list)
             {
                 Console.WriteLine(
                     $"Id: {pet.Id} || Name: {pet.Name} || Type: {pet.Type} || Price: {pet.Price}");
             }
         }
 
         public void PrintSortPetsBíPrice()
         {
             List<Pet> list = _petService.SortPetsByPrice();
             foreach (var pet in list)
             {
                 Console.WriteLine(
                     $"Id: {pet.Id} || Price: {pet.Price} || Name: {pet.Name} || Type: {pet.Type} || ");
             }
         }
 
         int PrintFindPetId()
         {
             Console.WriteLine("Type a pet id: ");
             int id;
             while (!int.TryParse(Console.ReadLine(), out id))
             {
                 Console.WriteLine("Please type a number");
             }
             return id;
         }
         string AskQuestion(string question)
         {
             Console.WriteLine(question);
             return Console.ReadLine();
         }
         public void UpdatePet(int id, string name, string type, DateTime bdate, DateTime sdate, string color, string powner, double price)
         {
             var pet = _petService.FindPetById(id);
             pet.Name = name;
             pet.Type = type;
             pet.BirthDate = bdate;
             pet.SoldDate = sdate;
             pet.Color = color;
             pet.PrevOwner = powner;
             pet.Price = price;
         }
     }*/
    }
}
