using System;
using Infrastructure.Data;
using PetShop.Core.ApplicationService;
using PetShop.Core.Domain;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetShopRepository repo = new PetShopRepository();
            ((PetShopRepository)repo).InitData();
            IPetShopService petservice = new PetShopService(repo);
            var printer = new Printer(petservice);
            //var selection = printer.ShowMenu();
            /*while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        printer.PrintAllPets();
                        break;
                    case 2:
                        Console.WriteLine("search pet type");
                        break;
                    case 3:
                        printer.CreatePet();
                        break;
                    case 4:
                        printer.DeletePet();
                        break;
                    case 5:
                        printer.UpdatePet();
                        break;
                    case 6:
                        Console.WriteLine("sort");
                        break;
                    case 7:
                        Console.WriteLine("top 5");
                        break;

                }
                selection = printer.ShowMenu();
            }
            Console.WriteLine("Bye!");
            Console.ReadLine();*/
            // printer.CreatePet();
            // printer.PrintAllPets();
        }
    }
}
